using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace Assessments
{
    using Assessments.LabExam01;
    class CustInfo
    {
        public int CId { get; set; }
        public string CName { get; set; }
        public string CAddress { get; set; }
        public int CMobile { get; set; }

        public CustInfo()
        {

        }
        public CustInfo(int id, string name, string address, int mobile)
        {
            this.CId = id;
            this.CName = name;
            this.CAddress = address;
            this.CMobile = mobile;
        }
    }

    class ProdInfo
    {
        public int PId { get; set; }
        public string PName { get; set; }
        public double PPrice { get; set; }

        public ProdInfo()
        {

        }

        public ProdInfo(int id, string name, double price)
        {
            this.PId = id;
            this.PName = name;
            this.PPrice = price;
        }
    }

    class BillingData
    { 
        public int BId { get; set; }
        public double Amount { get; set; }
        public int CId { get; set; }
        public int PId { get; set; }

        public BillingData()
        {

        }

        public BillingData(int bid, double amount, int cid, int pid)
        {
            this.BId = bid;
            this.Amount = amount;
            this.CId = cid;
            this.PId = pid;
        }
        
    }

    class Hackathon_Customer_Billing
    {'

        const string CONNECTIONSTRING = "Data Source=W-674PY03-2;Initial Catalog=Siddhi_DB;Persist Security Info=True;User ID=SA;Password=Password@123456-=";

        class CustBill : Customer
        { public void InsertCust()
            {
                string name = Utilities.GetString("Enter the name: ");
                string address = Utilities.GetString("Enter the address: ");
                int mobile = Utilities.GetInteger("Enter the mobile: ");
                CustInfo customer = new CustInfo(0, name, address, mobile);
                string query = $"Insert into CustInfo values('{customer.CName}', '{customer.CAddress}', {customer.CMobile})";
                SqlConnection con = new SqlConnection(CONNECTIONSTRING);
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 1)
                    {
                        Console.WriteLine("Customer inserted successfully!!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally {
                    con.Close();
                }
            }

            public void DeleteCust()
            {
                int cid = Utilities.GetInteger("Enter customer id; ");
                string query = $"Delete from CustInfo where CId = {cid}";
                SqlConnection con = new SqlConnection(CONNECTIONSTRING);
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 1)
                    {
                        Console.WriteLine("Customer details deleted successfully!!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            public void UpdateCust()
            {
                int cid = Utilities.GetInteger("Enter customer id; ");
                string name = Utilities.GetString("Enter the name: ");
                string address = Utilities.GetString("Enter the address: ");
                int mobile = Utilities.GetInteger("Enter the mobile: ");
                CustInfo customer = new CustInfo(cid, name, address, mobile);
                string query = $"Update CustInfo set CName='{customer.CName}', CAddress='{customer.CAddress}', CMobile={customer.CMobile} where CId = '{customer.CId}'";
                SqlConnection con = new SqlConnection(CONNECTIONSTRING);
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 1)
                    {
                        Console.WriteLine("Customer details updated successfully!!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            public void GetAllCust()
            {
                List<CustInfo> CustList = new List<CustInfo>();
                string query = $"Select * from CustInfo";
                SqlConnection con = new SqlConnection(CONNECTIONSTRING);
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        CustInfo customer = new CustInfo();
                        customer.CId = Convert.ToInt32(reader[0]);
                        customer.CName = reader[1].ToString();
                        customer.CAddress = reader[2].ToString();
                        customer.CMobile = Convert.ToInt32(reader[3]);
                        CustList.Add(customer);
                    }
                    foreach (var item in CustList)
                        Console.WriteLine(item.CId + ", " + item.CName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            public void GetAllProd()
            {
                List<ProdInfo> ProdList = new List<ProdInfo>();
                string query = $"Select * from ProdInfo";
                SqlConnection con = new SqlConnection(CONNECTIONSTRING);
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ProdInfo product = new ProdInfo();
                        product.PId = Convert.ToInt32(reader[0]);
                        product.PName = reader[1].ToString();
                        product.PPrice = Convert.ToInt32(reader[2]);
                        ProdList.Add(product);
                    }
                    foreach (var item in ProdList)
                        Console.WriteLine(item.PId + "," + item.PName + ", " + item.PPrice);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            public void FindCust()
            {
                int cid = Utilities.GetInteger("Enter the customer id: ");
                string query = $"select * from CustInfo where CId={cid}";
                SqlConnection con = new SqlConnection(CONNECTIONSTRING);
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var customer = new CustInfo();
                        customer.CId = Convert.ToInt32(reader[0]);
                        customer.CName = reader[1].ToString();
                        customer.CAddress = reader[2].ToString();
                        customer.CMobile = Convert.ToInt32(reader[3]);
                        Console.WriteLine(customer.CId + "," + customer.CName);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            public  void FindProd()
            {
                int pid = Utilities.GetInteger("Enter the product id: ");
                string query = $"select * from ProdInfo where PId={pid}";
                SqlConnection con = new SqlConnection(CONNECTIONSTRING);
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var product = new ProdInfo();
                        product.PId = Convert.ToInt32(reader[0]);
                        product.PName = reader[1].ToString();
                        product.PPrice = Convert.ToInt32(reader[2]);

                        Console.WriteLine(product.PId + "," + product.PName + "," + product.PPrice);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            public void InsertBill()
            {
                
                int CID = Utilities.GetInteger("Enter the Customer ID: ");

                string q1 = $"Select PId, Pname from ProdInfo";
                SqlConnection conn1 = new SqlConnection(CONNECTIONSTRING);
                SqlCommand command1 = new SqlCommand(q1, conn1);
                List<ProdInfo> pList = new List<ProdInfo>();
                try
                {
                    conn1.Open();
                    var red = command1.ExecuteReader();
                    while (red.Read())
                    {
                        var prod = new ProdInfo();
                        prod.PId = Convert.ToInt32(red[0]);
                        prod.PName = red[1].ToString();
                        pList.Add(prod);
                    }
                    Console.WriteLine($"Select product Id from the list of products given below:\n");
                    foreach (var item in pList)
                        Console.WriteLine(item.PId + " - " + item.PName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn1.Close();
                }
                int PID = Utilities.GetInteger("Enter the Product ID: ");

                string q = $"Select * from ProdInfo where PId={PID}";
                SqlConnection conn = new SqlConnection(CONNECTIONSTRING);
                SqlCommand command = new SqlCommand(q, conn);
                double x = 0;
                try
                {
                    conn.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var product = new ProdInfo();
                        product.PId = Convert.ToInt32(reader[0]);
                        product.PName = reader[1].ToString();
                        product.PPrice = Convert.ToInt32(reader[2]);
                        x = product.PPrice;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }

                string query = $"Insert into Billing values({x}, {CID}, {PID})";
                SqlConnection con = new SqlConnection(CONNECTIONSTRING);
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 1)
                    {
                        Console.WriteLine("Bill calculated successfully!!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            public void DisplayBill()
            {
                List<BillingData> BillList = new List<BillingData>();
                string query = $"Select * from Billing";
                SqlConnection con = new SqlConnection(CONNECTIONSTRING);
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        BillingData bill = new BillingData();
                        bill.BId = Convert.ToInt32(reader[0]);
                        bill.Amount = Convert.ToInt32(reader[1]);
                        bill.CId = Convert.ToInt32(reader[2]);
                        bill.PId = Convert.ToInt32(reader[3]);
                        BillList.Add(bill);
                    }
                    foreach (var item in BillList)
                        Console.WriteLine($"BillId: {item.BId}, CustId: {item.CId}, ProdId: {item.PId}, ProdPrice: {item.Amount}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            public void DisplayCustBill()
            {
                int Cid = Utilities.GetInteger("Enter the Cid: ");
                List<BillingData> BillList = new List<BillingData>();
                List<ProdInfo> prodList = new List<ProdInfo>();
                List<int> productIds = new List<int>();
                string query = $"Select * from Billing where CId={Cid}";
                SqlConnection con = new SqlConnection(CONNECTIONSTRING);
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        BillingData bill = new BillingData();
                        bill.BId = Convert.ToInt32(reader[0]);
                        bill.Amount = Convert.ToInt32(reader[1]);
                        bill.CId = Convert.ToInt32(reader[2]);
                        bill.PId = Convert.ToInt32(reader[3]);
                        BillList.Add(bill);
                        productIds.Add(bill.PId);
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
                string q3 = $"select CName from custinfo where CId={Cid}";
                SqlConnection con3 = new SqlConnection(CONNECTIONSTRING);
                SqlCommand cmd3 = new SqlCommand(q3, con3);
                var custId = new CustInfo();
                try
                {
                    con3.Open();
                    var read1 = cmd3.ExecuteReader();
                    while (read1.Read())
                    {
                        custId.CName = read1[0].ToString();
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con3.Close();
                }

                string sqlparam = string.Join(",", productIds);
                string q2 = $"select * from prodinfo where PId in ({sqlparam})";
                SqlConnection con2 = new SqlConnection(CONNECTIONSTRING);
                SqlCommand cmd2 = new SqlCommand(q2, con2);
                try
                {
                    con2.Open();
                    var read = cmd2.ExecuteReader();
                    while (read.Read())
                    {
                        ProdInfo prod = new ProdInfo();
                        prod.PId = Convert.ToInt32(read[0]);
                        prod.PName = read[1].ToString();
                        prod.PPrice = Convert.ToInt32(read[2]);
                        prodList.Add(prod);
                    }
                    double sum = 0;
                    foreach(var item in BillList)
                    {
                        sum += item.Amount;
                    }

                    Console.WriteLine($"Customer ID: {Cid}\nCustomer Name: {custId.CName}\nProducts purchased:\n");
                    foreach (var item in prodList)
                        Console.WriteLine(item.PId + " , " + item.PName + " , " + item.PPrice);
                    Console.WriteLine($"Total amount payable: {sum}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con2.Close();
                }
            }

        }

        static void Main(string[] args)
        {
            string menu = @"C:\Users\srajoria\source\repos\Assessments\Assessments\LabExam01\Menu.txt";
            string content = File.ReadAllText(menu);
            do
            {
                Console.WriteLine(content);
                Console.WriteLine("\n");
                string choice = Utilities.GetString("Enter the choice: ");
                var item = new CustBill();
                switch (choice.ToUpper())
                {
                    case "IC": item.InsertCust(); break;
                    case "DC": item.DeleteCust(); break;
                    case "UC": item.UpdateCust(); break;
                    case "FC": item.FindCust(); break;
                    case "FP": item.FindProd(); break;
                    case "AC": item.GetAllCust(); break;
                    case "AP": item.GetAllProd(); break;
                    case "MB": item.InsertBill(); break;
                    case "DB": item.DisplayBill(); break;
                    case "GB": item.DisplayCustBill(); break;
                    default: return;
                }
                Console.WriteLine("\n");
                Console.ReadLine();
                Console.Clear();
            } while (true);
        }
    }
}
