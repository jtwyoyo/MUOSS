namespace RequestManagement.Shared;
public class Transaction
{
    public int TransactionID { get; set; }
    public int StudentID { get; set; }
    public string FullName { get; set; }
    public DateTime RequestDate { get; set; }
    public double Amount { get; set; }
    public string Status { get; set; }
    public bool IsSelected { get; set; } = false;
}