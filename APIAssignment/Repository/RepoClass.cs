using APIAssignment.Models;
using APIAssignment.Controllers;
using Microsoft.Data.SqlClient;
using APIAssignment.Repository;
namespace APIAssignment.Repositories
{
    public class RepoClass : RepoInterface
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Book;Integrated Security=True;TrustServerCertificate=True");
        SqlCommand command = null;
        string qry = "";
        public void AddBooking(Book use)
        {
            try
            {
                qry = $"INSERT INTO book VALUES({use.bookingId},'{use.userName}',{use.price},'{use.bookingDate}','{use.flightName}',{use.flightId})";
                connection.Open();
                command = new SqlCommand(qry, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public Book GetBookingDetailsFromId(int id)
        {
            qry = "select * from book where bookingId= " + id;
            try
            {
                command = new SqlCommand(qry, connection);
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();
                Book book = null;
                if (dataReader.HasRows)
                {
                    dataReader.Read();

                    book = new Book()
                    {
                        bookingId = (int)dataReader[0],
                        userName = dataReader[1].ToString(),
                        price = (int)dataReader[2],
                        bookingDate = dataReader[3].ToString(),
                        flightName = dataReader[4].ToString(),
                        flightId = (int)dataReader[5]
                    };
                }

                return book;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }

            }
            public Book GetBookingDetailsFromName(string Name)
            {
                qry = "select * from book where name= " + Name;
                try
                {
                    command = new SqlCommand(qry, connection);
                    connection.Open();
                    SqlDataReader dataReader = command.ExecuteReader();
                    Book book = null;
                    if (dataReader.HasRows)
                    {
                        dataReader.Read();

                        book = new Book()
                        {
                            bookingId = (int)dataReader[0],
                            userName = dataReader[1].ToString(),
                            price = (int)dataReader[2],
                            bookingDate = dataReader[3].ToString(),
                            flightName = dataReader[4].ToString(),
                            flightId = (int)dataReader[5]
                        };
                    }

                    return book;

                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }

        public void DeleteBooking(int id)
        {
            try
            {
                qry = $"DELETE FROM book WHERE bookingId= "+id;
                connection.Open();
                command = new SqlCommand(qry, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public void UpdateBookingDate(int id, string updatedDate)
        {
            try
            {
                qry = $"UPDATE book SET bookingDate={updatedDate}" +
                    $"where bookingId={id}";
                connection.Open();
                command = new SqlCommand(qry, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
        }
        public void UpdateBookingUserName(int id,string Name)
        {
            try
            {
                qry = $"UPDATE book SET name={Name}" +
                    $"where bookingId={id}";
                connection.Open();
                command = new SqlCommand(qry, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Book> DisplayBookings()
        {
            qry = "select * from book";
            try
            {
                command = new SqlCommand(qry, connection);
                connection.Open(); 
                SqlDataReader dataReader = command.ExecuteReader();
                List<Book> books = new List<Book>();
                while (dataReader.Read()) 
                {
                    books.Add(new Book()
                    {
                        bookingId = (int)dataReader[0],
                        userName = dataReader[1].ToString(),
                        price = (int)dataReader[2],
                        bookingDate = dataReader[3].ToString(),
                        flightName = dataReader[4].ToString(),
                        flightId = (int)dataReader[5]
                    }) ;
                }
                return books;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
