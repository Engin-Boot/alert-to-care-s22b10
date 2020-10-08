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
            Npgsql.NpgsqlConnection con = null;
            try
            {
                con = DbConnection.GetConnection();
                // Inserting Patient Info in database.
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "insert into patient_info(patient_name, email, address, mobile) values(@patientName, @email, @address, @mobile)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("patientName", patient.patientName);
                    cmd.Parameters.AddWithValue("email", patient.email);
                    cmd.Parameters.AddWithValue("address", patient.address);
                    cmd.Parameters.AddWithValue("mobile", patient.mobile);
                    cmd.ExecuteNonQuery();
                }
                // Fetching Patient Info from database
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "select * from patient_info where patient_name = @patientName and" +
                                      " email=@email and address=@address and mobile=@mobile";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("patientName", patient.patientName);
                    cmd.Parameters.AddWithValue("email", patient.email);
                    cmd.Parameters.AddWithValue("address", patient.address);
                    cmd.Parameters.AddWithValue("mobile", patient.mobile);
                    NpgsqlDataReader dr = cmd.ExecuteReader();

                    // Output rows
                    while (dr.Read())
                    {
                        var patientRecord = new string[dr.FieldCount];
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            patientRecord[i] = dr[i].ToString();
                        }

                        return patientRecord;

                    }
                }
            }
        
            catch (Exception ex)
            {
                Console.WriteLine("Error");
            }
            finally
            {
                DbConnection.CloseConnection(con);
            }

            return null;
        }
    }
}
