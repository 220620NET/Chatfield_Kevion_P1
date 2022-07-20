using Models;
using Microsoft.Data.SqlClient;

public class ConnectionFactory
{
    private static ConnectionFactory? _instance;
    private readonly string _connectionString;
    private ConnectionFactory(string connectionString) 
    {
        _connectionString = connectionString;
    }
    

    // This is a getter for the one and only instance of connection factory
    public static ConnectionFactory GetInstance(string connectionString)
    {
        if(_instance == null)
        {
            _instance = new ConnectionFactory(connectionString);
        }
        return _instance;
    }

    public SqlConnection GetConnection()
    {
         return new SqlConnection(_connectionString);
    }

}