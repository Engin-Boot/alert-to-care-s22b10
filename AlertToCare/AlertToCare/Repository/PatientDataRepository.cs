using System;
using System.Data;
using AlertToCare.Context;
using AlertToCare.Models;
using AlertToCare.Utility;
using Npgsql;

namespace AlertToCare.Repository
{
    public class PatientDataRepository : IPatientDataRepository
    {
        private readonly PatientContext _context;

        public PatientDataRepository(PatientContext context)
        {
            _context = context;
        }

        public bool FreeTheBed(int patientId)
        {
            NpgsqlConnection con = null;
            try
            {
                con = DbConnection.GetConnection();
                // allot bed to patient
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "update bed_information SET patient_id = null where patient_id = @Patient_Id";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("Patient_Id", patientId);
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("unable to free the bed");
                return false;
            }
            return true;
        }

        public PatientDataModel FetchPatientInfoFromBedId(string bedId)
        {
            NpgsqlConnection con = null;
            try
            {
                con = DbConnection.GetConnection();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText =
                        "select * from patient_info where patient_id in(select patient_id from bed_information where bed_id=@bedId)";
                    cmd.Parameters.AddWithValue("bedId", bedId);
                    NpgsqlDataReader dr = cmd.ExecuteReader();
                    var count = dr.FieldCount;
                    return PopulatePatientObjectFromDataReader(dr);
                }
            }

            catch (Exception e)
            {
                throw new Exception("DB connectivity error");
            }
            finally
            {
                DbConnection.CloseConnection(con);
            }

            return null;
        }

        private PatientDataModel PopulatePatientObjectFromDataReader(NpgsqlDataReader dr)
        {
            PatientDataModel patientInfo= new PatientDataModel();
            while (dr.Read())
            {
                patientInfo.PatientName = dr[1].ToString();
                patientInfo.PatientId = int.Parse(dr[0].ToString());
                patientInfo.Email = dr[2].ToString();
                patientInfo.Address = dr[3].ToString();
                patientInfo.Mobile = dr[4].ToString();
            }

            return patientInfo;
        }

        public bool AllotBedToPatient(BedAllotmentModel allotBed)
        {
            NpgsqlConnection con = null;
            try
            {
                con = DbConnection.GetConnection();
                // allot bed to patient
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText =
                        " UPDATE bed_information SET patient_id = @PId WHERE bed_id IN " +
                        "(SELECT bed_id FROM bed_information WHERE patient_id IS NULL AND ward_number IN " +
                        "(SELECT ward_number FROM  icuwardinformation WHERE department=@Department) LIMIT 1)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("Department", allotBed.Department);
                    cmd.Parameters.AddWithValue("PId", allotBed.PatientId);
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("unable to allot bed2");
                return false;
            }
            return true;
        }

        /*public PatientDataModel InsertPatient(PatientDataModel patient)
        {
            NpgsqlConnection con = null;
            try
            {
                con = DbConnection.GetConnection();
                // Inserting Patient Info in database.
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText =
                        "insert into patient_info(patient_name, email, address, mobile) values(@patientName, @email, @address, @mobile)";
                    var command = FormQuery(cmd, patient);
                    command.ExecuteNonQuery();
                }

                // Fetching Patient Info from database
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "select * from patient_info where patient_name = @patientName and" +
                                      " email=@email and address=@address and mobile=@mobile";
                    var command = FormQuery(cmd, patient);
                    NpgsqlDataReader dr = command.ExecuteReader();

                    // Output rows
                    var patientRecord = PopulatePatientObjectFromDataReader(dr);
                    return patientRecord;

                }
            }

            catch (Exception)
            {
                throw new Exception("DB connectivity error");
            }
            finally
            {
                DbConnection.CloseConnection(con);
            }

        }*/

        public PatientDataModel InsertPatient(PatientDataModel patient)
        {
            _context.patient_info.Add(patient);
            _context.SaveChanges();
            return patient;
            
        }
        private NpgsqlCommand FormQuery(NpgsqlCommand cmd, PatientDataModel patient)
        {
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("patientName", patient.PatientName);
            cmd.Parameters.AddWithValue("email", patient.Email);
            cmd.Parameters.AddWithValue("address", patient.Address);
            cmd.Parameters.AddWithValue("mobile", patient.Mobile);
            return cmd;
        }

        
    }
}
