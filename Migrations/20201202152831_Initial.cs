using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JasperGreen18.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerFirstName = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerLastName = table.Column<string>(type: "TEXT", nullable: false),
                    BillingAddress = table.Column<string>(type: "TEXT", nullable: false),
                    BillingCity = table.Column<string>(type: "TEXT", nullable: false),
                    BillingState = table.Column<string>(type: "TEXT", nullable: false),
                    BillingZip = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    CustomerPhone = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeFirstName = table.Column<string>(type: "TEXT", nullable: false),
                    EmployeeLastName = table.Column<string>(type: "TEXT", nullable: false),
                    SSN = table.Column<string>(type: "TEXT", maxLength: 9, nullable: false),
                    JobTitle = table.Column<string>(type: "TEXT", nullable: false),
                    HireDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HourlyRate = table.Column<decimal>(type: "TEXT", nullable: false),
                    CrewForemanID = table.Column<int>(type: "INTEGER", nullable: false),
                    CrewMember1ID = table.Column<int>(type: "INTEGER", nullable: false),
                    CrewMember2ID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateID = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateID);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerID = table.Column<int>(type: "INTEGER", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PaymentAmount = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payments_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    PropertyID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerID = table.Column<int>(type: "INTEGER", nullable: false),
                    PropertyAddress = table.Column<string>(type: "TEXT", nullable: false),
                    PropertyCity = table.Column<string>(type: "TEXT", nullable: false),
                    PropertyState = table.Column<string>(type: "TEXT", nullable: false),
                    PropertyZip = table.Column<string>(type: "TEXT", nullable: false),
                    ServiceFee = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.PropertyID);
                    table.ForeignKey(
                        name: "FK_Properties_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Crews",
                columns: table => new
                {
                    CrewID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CrewForemanID = table.Column<int>(type: "INTEGER", nullable: false),
                    CrewMember1ID = table.Column<int>(type: "INTEGER", nullable: false),
                    CrewMember2ID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crews", x => x.CrewID);
                    table.ForeignKey(
                        name: "FK_Crews_Employees_CrewForemanID",
                        column: x => x.CrewForemanID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Crews_Employees_CrewMember1ID",
                        column: x => x.CrewMember1ID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Crews_Employees_CrewMember2ID",
                        column: x => x.CrewMember2ID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProvideServices",
                columns: table => new
                {
                    ServiceID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CrewID = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomerID = table.Column<int>(type: "INTEGER", nullable: false),
                    PropertyID = table.Column<int>(type: "INTEGER", nullable: false),
                    PaymentID = table.Column<int>(type: "INTEGER", nullable: false),
                    ServiceDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ServiceFee = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvideServices", x => x.ServiceID);
                    table.ForeignKey(
                        name: "FK_ProvideServices_Crews_CrewID",
                        column: x => x.CrewID,
                        principalTable: "Crews",
                        principalColumn: "CrewID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProvideServices_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProvideServices_Payments_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Payments",
                        principalColumn: "PaymentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProvideServices_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Properties",
                        principalColumn: "PropertyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "BillingAddress", "BillingCity", "BillingState", "BillingZip", "CustomerFirstName", "CustomerLastName", "CustomerPhone" },
                values: new object[] { 1, "6432 Elm Crest Ct", "College Station", "TX", "77840", "Susan", "Anthony", "8173083025" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "BillingAddress", "BillingCity", "BillingState", "BillingZip", "CustomerFirstName", "CustomerLastName", "CustomerPhone" },
                values: new object[] { 2, "2099 Alibi Rd", "Bryan", "TX", "77842", "Sarah", "Timmins", "9991029412" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "BillingAddress", "BillingCity", "BillingState", "BillingZip", "CustomerFirstName", "CustomerLastName", "CustomerPhone" },
                values: new object[] { 3, "87 Cool Plaza Rd", "College Station", "TX", "77844", "Mike", "Scott", "7281048294" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "BillingAddress", "BillingCity", "BillingState", "BillingZip", "CustomerFirstName", "CustomerLastName", "CustomerPhone" },
                values: new object[] { 4, "8243 Celtics Ave", "Bryan", "TX", "77816", "Larry", "Bird", "5927731088" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "BillingAddress", "BillingCity", "BillingState", "BillingZip", "CustomerFirstName", "CustomerLastName", "CustomerPhone" },
                values: new object[] { 5, "6172 Texas Ave S", "College Station", "TX", "77840", "Tim", "Morgan", "8229136239" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "CrewForemanID", "CrewMember1ID", "CrewMember2ID", "EmployeeFirstName", "EmployeeLastName", "HireDate", "HourlyRate", "JobTitle", "SSN" },
                values: new object[] { 15, 0, 0, 0, "Bruce", "Banner", new DateTime(2020, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 11.07m, "Foreman", "716809112" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "CrewForemanID", "CrewMember1ID", "CrewMember2ID", "EmployeeFirstName", "EmployeeLastName", "HireDate", "HourlyRate", "JobTitle", "SSN" },
                values: new object[] { 14, 0, 0, 0, "Jack", "Reacher", new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.05m, "Foreman", "516620901" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "CrewForemanID", "CrewMember1ID", "CrewMember2ID", "EmployeeFirstName", "EmployeeLastName", "HireDate", "HourlyRate", "JobTitle", "SSN" },
                values: new object[] { 13, 0, 0, 0, "Stephen", "Hamster", new DateTime(2020, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 9.49m, "Foreman", "623112013" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "CrewForemanID", "CrewMember1ID", "CrewMember2ID", "EmployeeFirstName", "EmployeeLastName", "HireDate", "HourlyRate", "JobTitle", "SSN" },
                values: new object[] { 12, 0, 0, 0, "Michael", "Jackson", new DateTime(2020, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 11.46m, "Foreman", "808976663" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "CrewForemanID", "CrewMember1ID", "CrewMember2ID", "EmployeeFirstName", "EmployeeLastName", "HireDate", "HourlyRate", "JobTitle", "SSN" },
                values: new object[] { 10, 0, 0, 0, "Alex", "Escobar", new DateTime(2020, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 12.19m, "Foreman", "221339153" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "CrewForemanID", "CrewMember1ID", "CrewMember2ID", "EmployeeFirstName", "EmployeeLastName", "HireDate", "HourlyRate", "JobTitle", "SSN" },
                values: new object[] { 9, 0, 0, 0, "Juan", "Rodriguez", new DateTime(2020, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.43m, "Foreman", "881904418" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "CrewForemanID", "CrewMember1ID", "CrewMember2ID", "EmployeeFirstName", "EmployeeLastName", "HireDate", "HourlyRate", "JobTitle", "SSN" },
                values: new object[] { 8, 0, 0, 0, "Jonah", "Hill", new DateTime(2020, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.00m, "Foreman", "829182197" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "CrewForemanID", "CrewMember1ID", "CrewMember2ID", "EmployeeFirstName", "EmployeeLastName", "HireDate", "HourlyRate", "JobTitle", "SSN" },
                values: new object[] { 11, 0, 0, 0, "Tanner", "Ray", new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 12.31m, "Foreman", "705628112" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "CrewForemanID", "CrewMember1ID", "CrewMember2ID", "EmployeeFirstName", "EmployeeLastName", "HireDate", "HourlyRate", "JobTitle", "SSN" },
                values: new object[] { 6, 0, 0, 0, "Clint", "Barton", new DateTime(2020, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.50m, "Foreman", "112772445" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "CrewForemanID", "CrewMember1ID", "CrewMember2ID", "EmployeeFirstName", "EmployeeLastName", "HireDate", "HourlyRate", "JobTitle", "SSN" },
                values: new object[] { 5, 0, 0, 0, "Tony", "Stark", new DateTime(2020, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 11.15m, "Basic Crew Member", "767889421" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "CrewForemanID", "CrewMember1ID", "CrewMember2ID", "EmployeeFirstName", "EmployeeLastName", "HireDate", "HourlyRate", "JobTitle", "SSN" },
                values: new object[] { 4, 0, 0, 0, "Peter", "Parker", new DateTime(2020, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.00m, "Basic Crew Member", "907665312" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "CrewForemanID", "CrewMember1ID", "CrewMember2ID", "EmployeeFirstName", "EmployeeLastName", "HireDate", "HourlyRate", "JobTitle", "SSN" },
                values: new object[] { 3, 0, 0, 0, "Adam", "Stevens", new DateTime(2020, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.00m, "Basic Crew Member", "191675544" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "CrewForemanID", "CrewMember1ID", "CrewMember2ID", "EmployeeFirstName", "EmployeeLastName", "HireDate", "HourlyRate", "JobTitle", "SSN" },
                values: new object[] { 2, 0, 0, 0, "James", "Smith", new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.11m, "Foreman", "819267345" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "CrewForemanID", "CrewMember1ID", "CrewMember2ID", "EmployeeFirstName", "EmployeeLastName", "HireDate", "HourlyRate", "JobTitle", "SSN" },
                values: new object[] { 1, 0, 0, 0, "Josh", "Tipton", new DateTime(2020, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 9.31m, "Foreman", "827937161" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "CrewForemanID", "CrewMember1ID", "CrewMember2ID", "EmployeeFirstName", "EmployeeLastName", "HireDate", "HourlyRate", "JobTitle", "SSN" },
                values: new object[] { 7, 0, 0, 0, "Chadwick", "Boseman", new DateTime(2020, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 11.23m, "Foreman", "322567256" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "OH", "Ohio" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "ND", "North Dakota" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "NC", "North Carolina" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "NY", "New York" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "NV", "Nevada" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "NJ", "New Jersey" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "NH", "New Hampshire" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "NE", "Nebraska" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "OK", "Oklahoma" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "NM", "New Mexico" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "OR", "Oregon" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "WA", "Washington" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "RI", "Rhode Island" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "SC", "South Carolina" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "SD", "South Dakota" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "TN", "Tennessee" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "TX", "Texas" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "UT", "Utah" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "VT", "Vermont" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "VA", "Virginia" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "MT", "Montana" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "WV", "West Virginia" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "PA", "Pennsylvania" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "MO", "Missouri" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "IA", "Iowa" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "MN", "Minnesota" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "AL", "Alabama" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "AK", "Alaska" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "AZ", "Arizona" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "AR", "Arkansas" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "CA", "California" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "CO", "Colorado" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "CT", "Connecticut" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "DE", "Delaware" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "DC", "District Of Columbia" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "FL", "Florida" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "GA", "Georgia" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "HI", "Hawaii" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "ID", "Idaho" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "IL", "Illinois" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "IN", "Indiana" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "WI", "Wisconsin" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "KS", "Kansas" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "KY", "Kentucky" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "LA", "Louisiana" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "ME", "Maine" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "MD", "Maryland" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "MA", "Massachusetts" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "MI", "Michigan" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "MS", "Mississippi" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateID", "Name" },
                values: new object[] { "WY", "Wyoming" });

            migrationBuilder.InsertData(
                table: "Crews",
                columns: new[] { "CrewID", "CrewForemanID", "CrewMember1ID", "CrewMember2ID" },
                values: new object[] { 5, 13, 14, 15 });

            migrationBuilder.InsertData(
                table: "Crews",
                columns: new[] { "CrewID", "CrewForemanID", "CrewMember1ID", "CrewMember2ID" },
                values: new object[] { 3, 7, 8, 9 });

            migrationBuilder.InsertData(
                table: "Crews",
                columns: new[] { "CrewID", "CrewForemanID", "CrewMember1ID", "CrewMember2ID" },
                values: new object[] { 2, 4, 5, 6 });

            migrationBuilder.InsertData(
                table: "Crews",
                columns: new[] { "CrewID", "CrewForemanID", "CrewMember1ID", "CrewMember2ID" },
                values: new object[] { 1, 1, 2, 3 });

            migrationBuilder.InsertData(
                table: "Crews",
                columns: new[] { "CrewID", "CrewForemanID", "CrewMember1ID", "CrewMember2ID" },
                values: new object[] { 4, 10, 11, 12 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentID", "CustomerID", "PaymentAmount", "PaymentDate" },
                values: new object[] { 8, 5, 165m, new DateTime(2020, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentID", "CustomerID", "PaymentAmount", "PaymentDate" },
                values: new object[] { 3, 5, 150m, new DateTime(2020, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentID", "CustomerID", "PaymentAmount", "PaymentDate" },
                values: new object[] { 9, 4, 225m, new DateTime(2020, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentID", "CustomerID", "PaymentAmount", "PaymentDate" },
                values: new object[] { 11, 3, 150m, new DateTime(2020, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentID", "CustomerID", "PaymentAmount", "PaymentDate" },
                values: new object[] { 2, 1, 225m, new DateTime(2020, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentID", "CustomerID", "PaymentAmount", "PaymentDate" },
                values: new object[] { 6, 3, 125m, new DateTime(2020, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentID", "CustomerID", "PaymentAmount", "PaymentDate" },
                values: new object[] { 10, 2, 300m, new DateTime(2020, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentID", "CustomerID", "PaymentAmount", "PaymentDate" },
                values: new object[] { 4, 2, 325m, new DateTime(2020, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentID", "CustomerID", "PaymentAmount", "PaymentDate" },
                values: new object[] { 1, 2, 200m, new DateTime(2020, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentID", "CustomerID", "PaymentAmount", "PaymentDate" },
                values: new object[] { 5, 1, 170m, new DateTime(2020, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentID", "CustomerID", "PaymentAmount", "PaymentDate" },
                values: new object[] { 7, 3, 190m, new DateTime(2020, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "PropertyID", "CustomerID", "PropertyAddress", "PropertyCity", "PropertyState", "PropertyZip", "ServiceFee" },
                values: new object[] { 4, 2, "2113 Mesquite Rd", "College Station", "TX", "77840", 69.99m });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "PropertyID", "CustomerID", "PropertyAddress", "PropertyCity", "PropertyState", "PropertyZip", "ServiceFee" },
                values: new object[] { 5, 4, "8121 South Beach Ct", "College Station", "TX", "77840", 125.00m });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "PropertyID", "CustomerID", "PropertyAddress", "PropertyCity", "PropertyState", "PropertyZip", "ServiceFee" },
                values: new object[] { 6, 4, "2111 Oho Ln", "College Station", "TX", "77840", 125.00m });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "PropertyID", "CustomerID", "PropertyAddress", "PropertyCity", "PropertyState", "PropertyZip", "ServiceFee" },
                values: new object[] { 3, 5, "216 Vanessa Ln", "College Station", "TX", "77840", 49.99m });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "PropertyID", "CustomerID", "PropertyAddress", "PropertyCity", "PropertyState", "PropertyZip", "ServiceFee" },
                values: new object[] { 2, 1, "9431 Brandon St", "College Station", "TX", "77839", 99.99m });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "PropertyID", "CustomerID", "PropertyAddress", "PropertyCity", "PropertyState", "PropertyZip", "ServiceFee" },
                values: new object[] { 1, 3, "4433 Elm  Ave", "College Station", "TX", "77840", 210.99m });

            migrationBuilder.InsertData(
                table: "ProvideServices",
                columns: new[] { "ServiceID", "CrewID", "CustomerID", "PaymentID", "PropertyID", "ServiceDate", "ServiceFee" },
                values: new object[] { 1, 1, 1, 1, 1, new DateTime(2020, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 80m });

            migrationBuilder.InsertData(
                table: "ProvideServices",
                columns: new[] { "ServiceID", "CrewID", "CustomerID", "PaymentID", "PropertyID", "ServiceDate", "ServiceFee" },
                values: new object[] { 4, 1, 1, 4, 5, new DateTime(2020, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 100m });

            migrationBuilder.InsertData(
                table: "ProvideServices",
                columns: new[] { "ServiceID", "CrewID", "CustomerID", "PaymentID", "PropertyID", "ServiceDate", "ServiceFee" },
                values: new object[] { 8, 1, 5, 8, 2, new DateTime(2020, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 225m });

            migrationBuilder.InsertData(
                table: "ProvideServices",
                columns: new[] { "ServiceID", "CrewID", "CustomerID", "PaymentID", "PropertyID", "ServiceDate", "ServiceFee" },
                values: new object[] { 9, 1, 2, 9, 2, new DateTime(2020, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 325m });

            migrationBuilder.InsertData(
                table: "ProvideServices",
                columns: new[] { "ServiceID", "CrewID", "CustomerID", "PaymentID", "PropertyID", "ServiceDate", "ServiceFee" },
                values: new object[] { 2, 3, 2, 2, 2, new DateTime(2020, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 60m });

            migrationBuilder.InsertData(
                table: "ProvideServices",
                columns: new[] { "ServiceID", "CrewID", "CustomerID", "PaymentID", "PropertyID", "ServiceDate", "ServiceFee" },
                values: new object[] { 5, 3, 4, 5, 2, new DateTime(2020, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 200m });

            migrationBuilder.InsertData(
                table: "ProvideServices",
                columns: new[] { "ServiceID", "CrewID", "CustomerID", "PaymentID", "PropertyID", "ServiceDate", "ServiceFee" },
                values: new object[] { 6, 3, 3, 6, 3, new DateTime(2020, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 250m });

            migrationBuilder.InsertData(
                table: "ProvideServices",
                columns: new[] { "ServiceID", "CrewID", "CustomerID", "PaymentID", "PropertyID", "ServiceDate", "ServiceFee" },
                values: new object[] { 7, 3, 5, 7, 2, new DateTime(2020, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 29.99m });

            migrationBuilder.InsertData(
                table: "ProvideServices",
                columns: new[] { "ServiceID", "CrewID", "CustomerID", "PaymentID", "PropertyID", "ServiceDate", "ServiceFee" },
                values: new object[] { 3, 4, 1, 3, 3, new DateTime(2020, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 120m });

            migrationBuilder.InsertData(
                table: "ProvideServices",
                columns: new[] { "ServiceID", "CrewID", "CustomerID", "PaymentID", "PropertyID", "ServiceDate", "ServiceFee" },
                values: new object[] { 10, 4, 4, 10, 4, new DateTime(2020, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 175m });

            migrationBuilder.CreateIndex(
                name: "IX_Crews_CrewForemanID",
                table: "Crews",
                column: "CrewForemanID");

            migrationBuilder.CreateIndex(
                name: "IX_Crews_CrewMember1ID",
                table: "Crews",
                column: "CrewMember1ID");

            migrationBuilder.CreateIndex(
                name: "IX_Crews_CrewMember2ID",
                table: "Crews",
                column: "CrewMember2ID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CustomerID",
                table: "Payments",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_CustomerID",
                table: "Properties",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_ProvideServices_CrewID",
                table: "ProvideServices",
                column: "CrewID");

            migrationBuilder.CreateIndex(
                name: "IX_ProvideServices_CustomerID",
                table: "ProvideServices",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_ProvideServices_PaymentID",
                table: "ProvideServices",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_ProvideServices_PropertyID",
                table: "ProvideServices",
                column: "PropertyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProvideServices");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Crews");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
