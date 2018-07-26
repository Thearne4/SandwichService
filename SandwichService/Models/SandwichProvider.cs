using System.Collections.Generic;
using System.Data.SqlClient;

namespace TheArne4.SandwichService.Models
{
    public class SandwichProvider
    {

        public static List<Sandwich> GetSandwiches()
        {

            List<Sandwich> sandwiches = new List<Sandwich>();
            using (SqlConnection myConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\GitRepos\GitHub\SandwichService\SandwichService\App_Data\SandwichDB.mdf;Integrated Security=True"))
            {
                string oString = "Select * from Sandwich";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                //oCmd.Parameters.AddWithValue("@Fname", fName);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        var sandwich = new Sandwich();
                        for (int iField = 0; iField < oReader.FieldCount; iField++)
                        {
                            switch (oReader.GetName(iField))
                            {
                                //case nameof(sandwich.Id).ToLowerInvariant():
                                case nameof(sandwich.Id):
                                    if (int.TryParse(oReader[iField] as string, out int id)) sandwich.Id = id;
                                    break;
                                case nameof(sandwich.Name):
                                    sandwich.Name = oReader[iField] as string;
                                    break;
                                case nameof(sandwich.Description):
                                    sandwich.Description = oReader[iField] as string;
                                    break;
                                case nameof(sandwich.Price):
                                    if (decimal.TryParse(oReader[iField] as string, out decimal dec)) sandwich.Price = dec;
                                    break;
                            }
                        }

                        sandwiches.Add(sandwich);
                    }
                    myConnection.Close();
                }
            }
            return sandwiches;
        }

        public static Sandwich GetSandwich(int id)
        {
            Sandwich sandwich = new Sandwich();
            using (SqlConnection myConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\GitRepos\GitHub\SandwichService\SandwichService\App_Data\SandwichDB.mdf;Integrated Security=True"))
            {
                string oString = "Select * from Sandwich where id = @id";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                oCmd.Parameters.AddWithValue("@id", id);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        for (int iField = 0; iField < oReader.FieldCount; iField++)
                        {
                            switch (oReader.GetName(iField))
                            {
                                case nameof(sandwich.Id):
                                    if (int.TryParse(oReader[iField] as string, out int dbId)) sandwich.Id = dbId;
                                    break;
                                case nameof(sandwich.Name):
                                    sandwich.Name = oReader[iField] as string;
                                    break;
                                case nameof(sandwich.Description):
                                    sandwich.Description = oReader[iField] as string;
                                    break;
                                case nameof(sandwich.Price):
                                    if (decimal.TryParse(oReader[iField] as string, out decimal dec)) sandwich.Price = dec;
                                    break;
                            }
                        }

                    }
                    myConnection.Close();
                }
            }
            return sandwich;
        }
    }
}