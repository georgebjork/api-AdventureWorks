using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Data.SqlClient;

namespace api_AdventureWorks.models;

// Use Table attribute to specify the table name
[Table("Customer")]
public class Customer
{
    // Use Column attribute to specify the column name and order
    [Key]
    [Column("CustomerID", Order = 0)]
    public int CustomerID { get; set; }

    [Column("NameStyle", Order = 1)]
    public bool NameStyle { get; set; }

    [Column("Title", Order = 2)]
    public string? Title { get; set; }

    [Column("FirstName", Order = 3)]
    public string FirstName { get; set; }

    [Column("MiddleName", Order = 4)]
    public string? MiddleName { get; set; }

    [Column("LastName", Order = 5)]
    public string LastName { get; set; }

    [Column("Suffix", Order = 6)]
    public string? Suffix { get; set; }

    [Column("CompanyName", Order = 7)]
    public string? CompanyName { get; set; }

    [Column("SalesPerson", Order = 8)]
    public string? SalesPerson { get; set; }

    [Column("EmailAddress", Order = 9)]
    public string EmailAddress { get; set; }

    [Column("Phone", Order = 10)]
    public string Phone { get; set; }

    [Column("PasswordHash", Order = 11)]
    public string PasswordHash { get; set; }

    [Column("PasswordSalt", Order = 12)]
    public string PasswordSalt { get; set; }

    [Key]
    [MaxLength(16)]
    [Timestamp]
    [Column("rowguid", Order = 13)]
    public Guid RowGuid { get; set; }

    [MaxLength(8)]
    [Timestamp]
    [Column("ModifiedDate", Order = 14)]
    public DateTime ModifiedDate { get; set; }


    public Customer(SqlDataReader dataReader) 
    {
        CustomerID = dataReader.GetInt32(dataReader.GetOrdinal("CustomerID"));
        NameStyle = dataReader.GetBoolean(dataReader.GetOrdinal("NameStyle"));
        Title = dataReader.IsDBNull(dataReader.GetOrdinal("Title")) ? null : dataReader.GetString(dataReader.GetOrdinal("Title"));
        FirstName = dataReader.GetString(dataReader.GetOrdinal("FirstName"));
        MiddleName = dataReader.IsDBNull(dataReader.GetOrdinal("MiddleName")) ? null : dataReader.GetString(dataReader.GetOrdinal("MiddleName"));
        LastName = dataReader.GetString(dataReader.GetOrdinal("LastName"));
        Suffix = dataReader.IsDBNull(dataReader.GetOrdinal("Suffix")) ? null : dataReader.GetString(dataReader.GetOrdinal("Suffix"));
        CompanyName = dataReader.IsDBNull(dataReader.GetOrdinal("CompanyName")) ? null : dataReader.GetString(dataReader.GetOrdinal("CompanyName"));
        SalesPerson = dataReader.IsDBNull(dataReader.GetOrdinal("SalesPerson")) ? null : dataReader.GetString(dataReader.GetOrdinal("SalesPerson"));
        EmailAddress = dataReader.GetString(dataReader.GetOrdinal("EmailAddress"));
        Phone = dataReader.GetString(dataReader.GetOrdinal("Phone"));
        PasswordHash = dataReader.GetString(dataReader.GetOrdinal("PasswordHash"));
        PasswordSalt = dataReader.GetString(dataReader.GetOrdinal("PasswordSalt"));
        RowGuid = dataReader.GetGuid(dataReader.GetOrdinal("RowGuid"));
        ModifiedDate = dataReader.GetDateTime(dataReader.GetOrdinal("ModifiedDate"));
    }

    public Customer(int customerID, bool nameStyle, string title, string firstName, string middleName, string lastName, string suffix, string companyName, string salesPerson, string emailAddress, string phone, string passwordHash, string passwordSalt, Guid rowGuid, DateTime modifiedDate)
    {
        CustomerID = customerID;
        NameStyle = nameStyle;
        Title = title;
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
        Suffix = suffix;
        CompanyName = companyName;
        SalesPerson = salesPerson;
        EmailAddress = emailAddress;
        Phone = phone;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        RowGuid = rowGuid;
        ModifiedDate = modifiedDate;
    }



    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string? ToString()
    {
        return base.ToString();
    }
}