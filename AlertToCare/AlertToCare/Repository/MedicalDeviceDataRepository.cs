using System;
using System.Collections.Generic;
using System.Data;
using AlertToCare.Models;
using AlertToCare.Utility;
using Npgsql;

namespace AlertToCare.Repository
{
    public class MedicalDeviceDataRepository : IMedicalDeviceDataRepository
    {
        public void InsertDevice(DeviceDataModel device)
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
                        "insert into medical_device values(@DeviceName, @MinValue, @MaxValue)";
                    var command = FormQuery(cmd, device);
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                throw new Exception("DB connectivity error");
            }
            finally
            {
                DbConnection.CloseConnection(con);
            }
        }
        private NpgsqlCommand FormQuery(NpgsqlCommand cmd, DeviceDataModel device)
        {
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("DeviceName", device.DeviceName);
            cmd.Parameters.AddWithValue("MinValue", device.MinValue);
            cmd.Parameters.AddWithValue("MaxValue", device.MaxValue);
            return cmd;
        }
        public IEnumerable<string> Alert(MedicalStatusDataModel medicalStatus)
        {
            NpgsqlConnection con = null;
            var alertingDevice = new List<string>();
            try
            {
                con = DbConnection.GetConnection();
                foreach (var medicalDevice in medicalStatus.MedicalDevice)
                {
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "select min_value, max_value from medical_device where device_name=@DeviceName;";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("DeviceName", medicalDevice.Key);
                        string[] values = null;
                        using (NpgsqlDataReader dr = cmd.ExecuteReader())
                        {
                            values = Utils.NpgsqlDataReaderToStringArrayConvertor(dr);
                        }

                        if (values == null || values.Length != 2)
                            {
                                throw new ArgumentException("Invalid medical device");
                            }

                            if (IsAlert(values, medicalDevice.Value))
                            {
                                BedOnAlertDataModel bed = new BedOnAlertDataModel();
                                bed.BedId = medicalStatus.BedId;
                                bed.DeviceName = medicalDevice.Key;
                                bed.value = medicalDevice.Value;
                                TurnOnAlert(con, bed);
                                alertingDevice.Add(medicalDevice.Key);
                            }
                    }
                }
                return alertingDevice;
            }
            catch(Exception e)
            {
                throw new Exception("DB connectivity error");
            }
            finally
            {
                DbConnection.CloseConnection(con);
            }
        }

        private void TurnOnAlert(NpgsqlConnection con, BedOnAlertDataModel Bed)
        {
            using (var cmd = new NpgsqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText =
                    "insert into bed_on_alert values(@BedId, @DeviceName, @Value)";
                cmd.Parameters.AddWithValue("BedId", Bed.BedId);
                cmd.Parameters.AddWithValue("DeviceName", Bed.DeviceName);
                cmd.Parameters.AddWithValue("Value", Bed.value);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    //pass
                }
            }
        }


        private bool IsAlert(string[] values, int medicalDeviceValue)
        {
            if(int.Parse(values[0]) > medicalDeviceValue || int.Parse(values[1]) < medicalDeviceValue)
                return true;
            return false;
        }
    }
}
