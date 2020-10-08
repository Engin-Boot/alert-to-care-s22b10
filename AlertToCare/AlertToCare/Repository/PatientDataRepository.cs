using System;
using System.Data;
using AlertToCare.Models;
using Npgsql;

namespace AlertToCare.Repository
{
    public class PatientDataRepository : IPatientDataRepository
    {
        public string[] InsertPatient(PatientDataModel patient)
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
                    var patientRecord = NpgsqlDataReaderToStringArrayConvertor(dr);
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

        private static string[] NpgsqlDataReaderToStringArrayConvertor(NpgsqlDataReader dr)
        {
            while (dr.Read())
            {
                var patientRecord = new string[dr.FieldCount];
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    patientRecord[i] = dr[i].ToString();
                }

                return patientRecord;
            }

            return null;
        }
    }
}
