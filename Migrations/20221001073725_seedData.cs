using Microsoft.EntityFrameworkCore.Migrations;

namespace InterviewAPI2.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "id", "AuthorName", "Name" },
                values: new object[,]
                {
                    { 1, "Joseph Murphy", "The Power of Your Mind" },
                    { 2, "Sri M", "Sri M: The Journey Continues" },
                    { 3, "Sri M", "Apprenticed To A Himalayan Master" },
                    { 4, "Shivram Karanth", "Mukajjiya Kanasugalu" },
                    { 5, "PoornaChandra Tejasvi", "Karvalo" },
                    { 6, "Paramahamsa Yogananda", "AutoBiography of A Yogi" },
                    { 7, "Chetan Bhagat", "A Night At A Call Center" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "id",
                keyValue: 7);
        }
    }
}
