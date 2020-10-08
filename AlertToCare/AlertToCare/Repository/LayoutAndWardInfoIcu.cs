using System;
using System.Data;
using AlertToCare.Models;
using Npgsql;

namespace AlertToCare.Repository
{
    public class LayoutAndWardInfoIcu : IIcuLayoutManagement
    {
        private bool IsAllBedAreEnteredInDb(int totalBed, int bedEnteredInDb)
        {
            return totalBed == bedEnteredInDb;
        }

        private bool BedLayoutAllocation(IcuWardLayoutModel objLayout)
        {
            try
            {
                bool flag = AddBedInIcu(objLayout);
                return flag;
            }
            catch
            {
                Console.WriteLine("can not connect to db");
                return false;
            }

            
        }

        private bool AddBedInIcu(IcuWardLayoutModel objLayout)
        {
            var con = DbConnection.GetConnection();
            int bedCounter = 1;
            for (int numberOfRow = 1; numberOfRow <= objLayout.NumberOfRow; numberOfRow++)
            {
                for (int numberOfColumn = 1; numberOfColumn <= objLayout.NumberOfColumn; numberOfColumn++)
                {
                    using var cmd = new NpgsqlCommand();
                    string bedId = string.Concat(objLayout.WardNumber, bedCounter.ToString());
                    int row = numberOfRow;
                    int column = numberOfColumn;
                    cmd.Connection = con;
                    cmd.CommandText =
                        "insert into bed_information(bed_id,ward_number,bed_in_row, bed_in_column) values(@bedId, @wardNumber, @bedInRow, @bedInColumn)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("bedId", bedId);
                    cmd.Parameters.AddWithValue("wardNumber", objLayout.WardNumber);
                    cmd.Parameters.AddWithValue("bedInRow", row);
                    cmd.Parameters.AddWithValue("bedInColumn", column);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    bedCounter++;
                    bool isAllBedAreEnteredInDb = IsAllBedAreEnteredInDb(objLayout.NumberOfBed, bedCounter);
                    if (isAllBedAreEnteredInDb)
                        return true;
                }
            }
            return true;
        }
        public bool GetLayoutInformation(IcuWardLayoutModel objLayout)
        {
            try
            {
                var con = DbConnection.GetConnection();
                // Inserting Patient Info in database.
                bool isBedLayoutIsEnterInDatabase = BedLayoutAllocation(objLayout);
                if (isBedLayoutIsEnterInDatabase == false)
                {
                    Console.WriteLine("Bed are not entered for ward "+objLayout.WardNumber);
                }

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "insert into icuwardinformation(ward_number, totalbed, department) values(@wardId, @roomCapacity, @Department)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("wardId", objLayout.WardNumber);
                    cmd.Parameters.AddWithValue("roomCapacity", objLayout.NumberOfBed);
                    cmd.Parameters.AddWithValue("Department", objLayout.Department);
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                Console.WriteLine("can not connect to db");
                return false;
            }
            return true;
        }

    }
}
