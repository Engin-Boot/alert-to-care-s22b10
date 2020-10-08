using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AlertToCare.Models;
using Npgsql;

namespace AlertToCare.Repository
{
    public class LayoutAndWardInfoIcu : IIcuLayoutManagement
    {
        public bool IsAllBedAreEnteredInDB(int totalBed, int bedEnteredInDB)
        {
            return totalBed == bedEnteredInDB;
        }
        public bool BedLayoutAllocation(IcuWardLayoutModel objLayout)
        {
            try
            {
                Npgsql.NpgsqlConnection con = null;
                con = DbConnection.GetConnection();
                int bedCounter = 1;
                for (int numberOfRow = 1; numberOfRow <= objLayout.NumberOfRow; numberOfRow++)
                {
                    for (int numberOfColumn = 1; numberOfColumn <= objLayout.NumberOfColumn; numberOfColumn++)
                    {
                        using (var cmd = new NpgsqlCommand())
                        {
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
                            bedCounter++;
                            bool isAllBedAreEnteredInDB = IsAllBedAreEnteredInDB(objLayout.NumberOfBed, bedCounter);
                            if (isAllBedAreEnteredInDB)
                                return true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("can not connect to db");
                return false;
            }

            return true;
        }
        public bool GetLayoutInformation(IcuWardLayoutModel objLayout)
        {
            try
            {
                Npgsql.NpgsqlConnection con = null;
                con = DbConnection.GetConnection();
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
            catch (Exception e)
            {
                Console.WriteLine("can not connect to db");
                return false;
            }
            return true;
        }

    }
}
