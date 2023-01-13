
// Create view model and 
// initialize the Entity object
using DataAnnotations;

#region Demo #1.
ProductViewModel vm = new()
{
    Entity = new()
    {
        Name = "",
        ListPrice = 5,
        StandardCost = 15
    }
};
#endregion

#region Demo #2. ValidationContext, [Required], ErrorMessage to [Required], [Displayname].
//ProductViewModel vm = new()
//{
//    Entity = new()
//    {
//        ProductID = 1,
//        Name = "",
//        ProductNumber = ""
//    }
//};
#endregion

#region Demo #3. [MaxLength].
//ProductViewModel vm = new()
//{
//    Entity = new()
//    {
//        ProductID = 1,
//        Name = "Product 1",
//        ProductNumber = "A very long product name to illustrate the [MaxLength] property.",
//        Color = "A very long color name."
//    }
//};
#endregion

#region Demo #4. [MinLength].
//ProductViewModel vm = new()
//{
//    Entity = new()
//    {
//        ProductID = 1,
//        Name = "Product 1",
//        ProductNumber = "PROD001",
//        Color = "Re"
//    }
//};
#endregion

#region Demo #5. [StringLength].
//ProductViewModel vm = new()
//{
//    Entity = new()
//    {
//        ProductID = 1,
//        Name = "A"   // For MinLength.
//        //Name = "A very long product name used to illustrate[StringLength] attribute." // For MaxLength
//    }
//};
#endregion

#region Demo #6. [Range].
//ProductViewModel vm = new()
//{
//    Entity = new()
//    {
//        ProductID = 1,
//        Name = "A New Product",
//        ProductNumber = "PROD001",
//        Color = "Black",
//        StandardCost = 0,
//        ListPrice = 10000,
//        SellStartDate = DateTime.Now,
//        SellEndDate = DateTime.Now.AddDays(+365)
//    }
//};
#endregion

#region Demo #7. [Range] with DateTime.
//ProductViewModel vm = new()
//{
//    Entity = new()
//    {
//        ProductID = 1,
//        Name = "A New Product",
//        ProductNumber = "PROD001",
//        Color = "Black",
//        StandardCost = 1,
//        ListPrice = 10,
//        SellStartDate = Convert.ToDateTime("1/1/1999"),
//        SellEndDate = Convert.ToDateTime("1/1/2031")
//    }
//};
#endregion

#region Demo #8. [RegularExpression].
//UserViewModel vm = new()
//{
//    Entity = new()
//    {
//        UserId = 1,
//        LoginId = "JoeSmith",
//        Password = "Joe!Smith@2022",
//        EmailAddress = "test!test.com",
//        Phone = "xxx-xxx-xxxx"
//    }
//};
#endregion

#region Demo #9. [Compare].
//UserViewModel vm = new()
//{
//    Entity = new()
//    {
//        UserId = 1,
//        LoginId = "JoeSmith",
//        Password = "JoeSmith@2022",
//        ConfirmPassword = "JoeSmith",
//        EmailAddress = "JoeSmith@test.com",
//        Phone = "(999) 999-9999",
//    }
//};
#endregion

#region Demo #10. [Url] for Product.
//ProductViewModel vm = new()
//{
//    Entity = new()
//    {
//        ProductID = 1,
//        Name = "A New Product",
//        Color = "Black",
//        StandardCost = 5,
//        ListPrice = 10,
//        ProductUrl = "asdf.test"
//    }
//};
#endregion

#region Demo #11. [CreditCard] for CreditCard.
//CreditCardViewModel vm = new()
//{
//    Entity = new()
//    {
//        CardType = "Visa",
//        CardNumber = "12 13 123 1234",
//        NameOnCard = "Joe Smith",
//        BillingPostalCode = "99999",
//        ExpMonth = 01,
//        ExpYear = 2026,
//        SecurityCode = "000"
//    }
//};
#endregion

#region Demo #12. Custom Validator [WeekdayOnlyValidator] on Customer.
//CustomerViewModel vm = new()
//{
//    Entity = new()
//    {
//        EntryDate = DateTime.Parse("8/1/2023")  // 08-Jan-2023 Sunday.
//    }
//};
#endregion

#region Demo #13. Custom Validator [DateMinimum] on Product.DiscontinuedDate.
//ProductViewModel vm = new()
//{
//    Entity = new()
//    {
//        ProductID = 1,
//        Name = "A New Product",
//        ProductNumber = "PROD001",
//        Color = "Red",
//        StandardCost = 5,
//        ListPrice = 12,
//        SellStartDate = DateTime.Today,
//        SellEndDate = DateTime.Today.AddYears(+5),
//        DiscontinuedDate =
//      Convert.ToDateTime("1/1/2020")
//    }
//};
#endregion

#region Demo #14. Custom Validator [DateMaximum] on Product.SellEndDate.
//ProductViewModel vm = new()
//{
//    Entity = new()
//    {
//        ProductID = 1,
//        Name = "A New Product",
//        ProductNumber = "PROD001",
//        Color = "Red",
//        StandardCost = 5,
//        ListPrice = 12,
//        SellStartDate = DateTime.Today,
//        SellEndDate = DateTime.Today.AddYears(+20),
//        DiscontinuedDate = Convert.ToDateTime("15/12/2022")
//    }
//};
#endregion

// Validate the Data
var msgs = vm.Validate();

// Display Failed Validation Messages
foreach (ValidationMessage item in msgs)
{
    Console.WriteLine(item);
}

// Display Total Count
Console.WriteLine();
Console.WriteLine($"Total Validations Failed: {msgs.Count}");

// Pause for Results
Console.ReadKey();
