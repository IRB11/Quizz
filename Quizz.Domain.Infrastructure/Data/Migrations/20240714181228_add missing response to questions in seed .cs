using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Quizz.Domain.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addmissingresponsetoquestionsinseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CompletionTime",
                value: new DateTime(2024, 7, 14, 18, 12, 28, 449, DateTimeKind.Utc).AddTicks(6946));

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CompletionTime",
                value: new DateTime(2024, 7, 14, 18, 12, 28, 449, DateTimeKind.Utc).AddTicks(6951));

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "Id", "Content", "IsCorrect", "QuestionId" },
                values: new object[,]
                {
                    { 481, "A class is a blueprint for creating objects.", true, 21 },
                    { 482, "An object is an instance of a class.", true, 21 },
                    { 483, "Classes define properties and methods.", true, 21 },
                    { 484, "Objects hold specific data and can perform actions.", true, 21 },
                    { 485, "Abstraction is the concept of hiding the complex implementation details.", true, 22 },
                    { 486, "It focuses on exposing only the necessary parts.", true, 22 },
                    { 487, "Abstraction helps in reducing programming complexity.", true, 22 },
                    { 488, "It is achieved using abstract classes and interfaces.", true, 22 },
                    { 489, "The 'finally' block is used to execute important code such as closing resources.", true, 23 },
                    { 490, "It always executes, regardless of whether an exception was thrown or not.", true, 23 },
                    { 491, "It is used to perform cleanup operations.", true, 23 },
                    { 492, "The 'finally' block can be used with try-catch blocks.", true, 23 },
                    { 493, "A primary key uniquely identifies each record in a table.", true, 24 },
                    { 494, "A foreign key is a field in one table that uniquely identifies a row of another table.", true, 24 },
                    { 495, "Primary keys enforce entity integrity.", true, 24 },
                    { 496, "Foreign keys enforce referential integrity.", true, 24 },
                    { 497, "Normalization is the process of organizing data to reduce redundancy.", true, 25 },
                    { 498, "It involves dividing a database into two or more tables and defining relationships between them.", true, 25 },
                    { 499, "Normalization improves data integrity.", true, 25 },
                    { 500, "It helps in efficient data retrieval.", true, 25 },
                    { 501, "The 'static' keyword is used to indicate that a member belongs to the class, rather than instances of the class.", true, 26 },
                    { 502, "Static members are shared among all instances of the class.", true, 26 },
                    { 503, "Static methods can be called without creating an instance of the class.", true, 26 },
                    { 504, "Static variables are initialized only once, at the start of the execution.", true, 26 },
                    { 505, "Method overloading allows a class to have more than one method with the same name.", true, 27 },
                    { 506, "Overloaded methods must have different parameter lists.", true, 27 },
                    { 507, "It is a way to achieve polymorphism.", true, 27 },
                    { 508, "Overloading improves code readability and reusability.", true, 27 },
                    { 509, "GET requests are used to retrieve data from a server.", true, 28 },
                    { 510, "POST requests are used to send data to a server to create/update a resource.", true, 28 },
                    { 511, "GET requests can be cached and bookmarked.", true, 28 },
                    { 512, "POST requests are not cached and cannot be bookmarked.", true, 28 },
                    { 513, "The 'volatile' keyword is used to indicate that a variable's value may be changed by different threads.", true, 29 },
                    { 514, "It ensures that the value of the variable is always read from the main memory.", true, 29 },
                    { 515, "Volatile variables are not cached thread-locally.", true, 29 },
                    { 516, "It is used to prevent memory consistency errors.", true, 29 },
                    { 517, "A RESTful API is an API that conforms to the constraints of REST architecture.", true, 30 },
                    { 518, "It uses standard HTTP methods like GET, POST, PUT, DELETE.", true, 30 },
                    { 519, "RESTful APIs are stateless and cacheable.", true, 30 },
                    { 520, "They use URIs to access resources.", true, 30 },
                    { 521, "A process is an independent program in execution.", true, 31 },
                    { 522, "A thread is a smaller unit of a process that can be executed independently.", true, 31 },
                    { 523, "Processes have separate memory spaces.", true, 31 },
                    { 524, "Threads share the same memory space within a process.", true, 31 },
                    { 525, "A lambda expression is a concise way to represent an anonymous function.", true, 32 },
                    { 526, "It provides a clear and concise way to implement a single method interface.", true, 32 },
                    { 527, "Lambda expressions are used primarily to define the inline implementation of a functional interface.", true, 32 },
                    { 528, "They help in writing more readable and maintainable code.", true, 32 },
                    { 529, "The 'transient' keyword is used to indicate that a field should not be serialized.", true, 33 },
                    { 530, "Transient fields are not included in the serialized form of an object.", true, 33 },
                    { 531, "It is used to prevent sensitive data from being serialized.", true, 33 },
                    { 532, "Transient fields are initialized with default values during deserialization.", true, 33 },
                    { 533, "A constructor is a special method used to initialize objects.", true, 34 },
                    { 534, "A method is a function defined in a class that performs a specific task.", true, 34 },
                    { 535, "Constructors do not have a return type.", true, 34 },
                    { 536, "Methods have a return type or void.", true, 34 },
                    { 537, "A binary tree is a tree data structure in which each node has at most two children.", true, 35 },
                    { 538, "The two children are referred to as the left child and the right child.", true, 35 },
                    { 539, "Binary trees are used in various applications such as searching and sorting.", true, 35 },
                    { 540, "They are the basis for binary search trees and binary heaps.", true, 35 },
                    { 541, "The 'synchronized' keyword is used to control the access of multiple threads to a shared resource.", true, 36 },
                    { 542, "It ensures that only one thread can access the resource at a time.", true, 36 },
                    { 543, "Synchronized methods or blocks prevent thread interference and memory consistency errors.", true, 36 },
                    { 544, "It is used to implement thread-safe operations.", true, 36 },
                    { 545, "A hash table is a data structure that maps keys to values using a hash function.", true, 37 },
                    { 546, "It provides efficient insertion, deletion, and lookup operations.", true, 37 },
                    { 547, "Hash tables handle collisions using techniques like chaining or open addressing.", true, 37 },
                    { 548, "They are widely used in applications requiring fast data retrieval.", true, 37 },
                    { 549, "A stack is a linear data structure that follows the LIFO (Last In, First Out) principle.", true, 38 },
                    { 550, "A heap is a specialized tree-based data structure that satisfies the heap property.", true, 38 },
                    { 551, "Stacks are used for static memory allocation.", true, 38 },
                    { 552, "Heaps are used for dynamic memory allocation.", true, 38 },
                    { 553, "The 'finalize' method is called by the garbage collector before an object is destroyed.", true, 39 },
                    { 554, "It is used to perform cleanup operations before the object is reclaimed.", true, 39 },
                    { 555, "The 'finalize' method is not guaranteed to be called immediately after an object becomes unreachable.", true, 39 },
                    { 556, "The 'map' function creates a new array populated with the results of calling a provided function on every element in the calling array.", true, 117 },
                    { 557, "The 'map' function does not change the original array.", false, 117 },
                    { 558, "The 'map' function is used to filter elements in an array.", false, 117 },
                    { 559, "The 'map' function is used to reduce elements in an array.", false, 117 },
                    { 560, "The 'filter' function creates a new array with all elements that pass the test implemented by the provided function.", true, 118 },
                    { 561, "The 'filter' function changes the original array.", false, 118 },
                    { 562, "The 'filter' function is used to map elements in an array.", false, 118 },
                    { 563, "The 'filter' function is used to reduce elements in an array.", false, 118 },
                    { 564, "The 'reduce' function executes a reducer function on each element of the array, resulting in a single output value.", true, 119 },
                    { 565, "The 'reduce' function creates a new array.", false, 119 },
                    { 566, "The 'reduce' function is used to filter elements in an array.", false, 119 },
                    { 567, "The 'reduce' function is used to map elements in an array.", false, 119 },
                    { 568, "The 'find' function returns the value of the first element in the array that satisfies the provided testing function.", true, 120 },
                    { 569, "The 'find' function returns a new array.", false, 120 },
                    { 570, "The 'find' function is used to filter elements in an array.", false, 120 },
                    { 571, "The 'find' function is used to map elements in an array.", false, 120 },
                    { 572, "The 'find' function returns the value of the first element in the array that satisfies the provided testing function.", true, 120 },
                    { 573, "The 'find' function returns a new array.", false, 120 },
                    { 574, "The 'find' function is used to filter elements in an array.", false, 120 },
                    { 575, "The 'find' function is used to map elements in an array.", false, 120 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 481);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 482);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 483);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 484);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 485);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 486);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 487);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 488);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 489);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 490);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 491);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 492);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 493);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 494);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 495);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 496);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 497);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 498);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 499);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 500);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 501);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 502);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 503);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 504);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 505);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 506);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 507);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 508);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 509);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 510);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 511);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 512);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 513);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 514);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 515);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 516);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 517);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 518);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 519);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 520);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 521);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 522);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 523);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 524);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 525);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 526);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 527);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 528);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 529);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 530);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 531);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 532);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 533);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 534);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 535);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 536);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 537);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 538);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 539);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 540);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 541);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 542);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 543);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 544);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 545);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 546);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 547);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 548);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 549);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 550);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 551);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 552);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 553);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 554);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 555);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 556);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 557);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 558);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 559);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 560);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 561);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 562);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 563);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 564);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 565);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 566);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 567);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 568);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 569);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 570);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 571);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 572);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 573);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 574);

            migrationBuilder.DeleteData(
                table: "Responses",
                keyColumn: "Id",
                keyValue: 575);

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CompletionTime",
                value: new DateTime(2024, 7, 11, 8, 7, 33, 491, DateTimeKind.Utc).AddTicks(7386));

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CompletionTime",
                value: new DateTime(2024, 7, 11, 8, 7, 33, 491, DateTimeKind.Utc).AddTicks(7390));
        }
    }
}
