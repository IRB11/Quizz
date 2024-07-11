using Quizz.Domain.Core.Dto;

namespace Quizz.Domain.Infrastructure.InMemory
{
    public static class MockData
    {
        public static List<QuestionResponse> Questions = new List<QuestionResponse>
        {
            new QuestionResponse
            {
                Id = 2,  // Changed ID to be unique
                Content = "Quelle est l'extension d'un fichier de projet .NET ?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 1, Content = " .csproj", isCorrect = true },
                    new Response_Response { Id = 2, Content = ".vbproj", isCorrect = false },
                    new Response_Response { Id = 3, Content = " .fsproj", isCorrect = false },  // Corrected duplicate ID
                    new Response_Response { Id = 4, Content = "Toutes les réponses ci-dessus", isCorrect = false }  // Corrected duplicate ID
                },
                Level = new() { Id = 1},
                Technology = new() { Id = 1},
            },

            new QuestionResponse
            {
                Id = 3,
                Content = "Quelle est la méthode d'entrée principale pour une application console en C# ?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 1, Content = "Main", isCorrect = true },
                    new Response_Response { Id = 2, Content = "Start", isCorrect = false },
                    new Response_Response { Id = 3, Content = "Run", isCorrect = false },
                    new Response_Response { Id = 4, Content = "Begin", isCorrect = false }
                },
                Level = new() { Id = 1},
                Technology = new() { Id = 1},

            },

            new QuestionResponse
            {
                Id = 4,
                Content = "Quel est le mot-clé pour déclarer une variable en C#",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 1, Content = "var", isCorrect = true },
                    new Response_Response { Id = 2, Content = "let", isCorrect = false },
                    new Response_Response { Id = 3, Content = "def", isCorrect = false },
                    new Response_Response { Id = 4, Content = "int", isCorrect = false }
                },
                Level = new() { Id = 1},
                Technology = new() { Id = 1}

            },

            new QuestionResponse
            {
                Id = 5,
                Content = "What is the capital of France?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 1, Content = "var", isCorrect = true },
                    new Response_Response { Id = 2, Content = "let", isCorrect = false },
                    new Response_Response { Id = 3, Content = "def", isCorrect = false },
                    new Response_Response { Id = 4, Content = "int", isCorrect = false }
                },
                Level = new() { Id = 1},
                Technology = new() { Id = 1},

            },

            new QuestionResponse
            {
                Id = 6,
                Content = "What is the capital of France?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 1, Content = "var", isCorrect = true },
                    new Response_Response { Id = 2, Content = "let", isCorrect = false },
                    new Response_Response { Id = 3, Content = "def", isCorrect = true },
                    new Response_Response { Id = 4, Content = "int", isCorrect = false }
                },
                Level = new() { Id = 1},
                Technology = new() { Id = 1},

            },

            new QuestionResponse
            {
                Id = 7,
                Content = "What is the capital of France?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 1, Content = "Paris", isCorrect = true },
                    new Response_Response { Id = 2, Content = "Berlin", isCorrect = false }
                },
                Level = new() { Id = 1},
                Technology = new() { Id = 1},

            },

            new QuestionResponse
            {
                Id = 8,
                Content = "What is the capital of France?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 1, Content = "Paris", isCorrect = true },
                    new Response_Response { Id = 2, Content = "Berlin", isCorrect = false }
                },
                Level = new() { Id = 1},
                Technology = new() { Id = 1},

            },

            new QuestionResponse
            {
                Id = 9,
                Content = "What is the capital of France?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 1, Content = "Paris", isCorrect = true },
                    new Response_Response { Id = 2, Content = "Berlin", isCorrect = false }
                },
                Level = new() { Id = 1},
                Technology = new() { Id = 1},

            },

            new QuestionResponse
            {
                Id = 10,
                Content = "What is the capital of France?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 1, Content = "Paris", isCorrect = true },
                    new Response_Response { Id = 2, Content = "Berlin", isCorrect = false }
                },
                Level = new() { Id = 1},
                Technology = new() { Id = 1},

            },

            new QuestionResponse
            {
                Id = 11,
                Content = "What is the capital of France?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 1, Content = "Paris", isCorrect = true },
                    new Response_Response { Id = 2, Content = "Berlin", isCorrect = false }
                },
                Level = new() { Id = 1},
                Technology = new() { Id = 1},

            },
            //10
            new QuestionResponse
            {
                Id = 12,
                Content = "What is the capital of France?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 1, Content = "Paris", isCorrect = true },
                    new Response_Response { Id = 2, Content = "Berlin", isCorrect = false }
                },
                Level = new() { Id = 1},
                Technology = new() { Id = 1},

            },

            new QuestionResponse
            {
                Id = 13,
                Content = "What is the capital of France?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 1, Content = "Paris", isCorrect = true },
                    new Response_Response { Id = 2, Content = "Berlin", isCorrect = false }
                },
                Level = new() { Id = 1},
                Technology = new() { Id = 1},

            },

            new QuestionResponse
            {
                Id = 14,
                Content = "What is the capital of France?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 1, Content = "Paris", isCorrect = true },
                    new Response_Response { Id = 2, Content = "Berlin", isCorrect = false }
                },
                Level = new() { Id = 1},
                Technology = new() { Id = 1},

            },

            new QuestionResponse
            {
                Id = 15,
                Content = "What is the capital of France?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 1, Content = "Paris", isCorrect = true },
                    new Response_Response { Id = 2, Content = "Berlin", isCorrect = false }
                },
                Level = new() { Id = 1},
                Technology = new() { Id = 1},

            },

            new QuestionResponse
            {
                Id = 16,
                Content = "What is the capital of France?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 1, Content = "Paris", isCorrect = true },
                    new Response_Response { Id = 2, Content = "Berlin", isCorrect = false }
                },
                Level = new() { Id = 1},
                Technology = new() { Id = 1},

            },

            new QuestionResponse
            {
                Id = 17,
                Content = "What is the capital of France?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 1, Content = "Paris", isCorrect = true },
                    new Response_Response { Id = 2, Content = "Berlin", isCorrect = false }
                },
                Level = new() { Id = 1},
                Technology = new() { Id = 1},

            },

            new QuestionResponse
            {
                Id = 18,
                Content = "What is the capital of France?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 1, Content = "Paris", isCorrect = true },
                    new Response_Response { Id = 2, Content = "Berlin", isCorrect = false }
                },
                Level = new() { Id = 1},
                Technology = new() { Id = 1},

            },

            new QuestionResponse
            {
                Id = 19,
                Content = "What is the capital of France?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 1, Content = "Paris", isCorrect = true },
                    new Response_Response { Id = 2, Content = "Berlin", isCorrect = false }
                },
                Level = new() { Id = 1},
                Technology = new() { Id = 1},

            },

            new QuestionResponse
            {
                Id = 20,
                Content = "What is the capital of France?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 1, Content = "Paris", isCorrect = true },
                    new Response_Response { Id = 2, Content = "Berlin", isCorrect = false }
                },
                Level = new() { Id = 1},
                Technology = new() { Id = 1},

            },

            new QuestionResponse
            {
                Id = 21,
                Content = "What is the capital of France?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 1, Content = "Paris", isCorrect = true },
                    new Response_Response { Id = 2, Content = "Berlin", isCorrect = false }
                },
                Level = new() { Id = 1},
                Technology = new() { Id = 1},

            },
            //20
            new QuestionResponse
            {
                Id = 22,
                Content = "What is the capital of France?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 1, Content = "Paris", isCorrect = true },
                    new Response_Response { Id = 2, Content = "Berlin", isCorrect = false }
                },
                Level = new() { Id = 1},
                Technology = new() { Id = 1},

            },

            new QuestionResponse
            {
                Id = 23,
                Content = "What is the capital of France?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 1, Content = "Paris", isCorrect = true },
                    new Response_Response { Id = 2, Content = "Berlin", isCorrect = false }
                },
                Level = new() { Id = 1},
                Technology = new() { Id = 1},

            },

            new QuestionResponse
            {
                Id = 24,
                Content = "What is the capital of France?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 1, Content = "Paris", isCorrect = true },
                    new Response_Response { Id = 2, Content = "Berlin", isCorrect = false }
                },
                Level = new() { Id = 1},
                Technology = new() { Id = 1},

            },

            new QuestionResponse
            {
                Id = 25,
                Content = "What is the capital of France?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 1, Content = "Paris", isCorrect = true },
                    new Response_Response { Id = 2, Content = "Berlin", isCorrect = false }
                },
                Level = new() { Id = 1},
                Technology = new() { Id = 1},

            },

            new QuestionResponse
            {
                Id = 26,
                Content = "What is the capital of France?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 1, Content = "Paris", isCorrect = true },
                    new Response_Response { Id = 2, Content = "Berlin", isCorrect = false }
                },
                Level = new() { Id = 1},
                Technology = new() { Id = 1},

            },

            new QuestionResponse
            {
                Id = 27,
                Content = "What is the capital of France?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 1, Content = "Paris", isCorrect = true },
                    new Response_Response { Id = 2, Content = "Berlin", isCorrect = false }
                },
                Level = new() { Id = 1},
                Technology = new() { Id = 1},

            },

            new QuestionResponse
            {
                Id = 28,
                Content = "What is the capital of France?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 1, Content = "Paris", isCorrect = true },
                    new Response_Response { Id = 2, Content = "Berlin", isCorrect = false }
                },
                Level = new() { Id = 1},
                Technology = new() { Id = 1},

            },

            new QuestionResponse
            {
                Id = 29,
                Content = "What is the capital of France?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 1, Content = "Paris", isCorrect = true },
                    new Response_Response { Id = 2, Content = "Berlin", isCorrect = false }
                },
                Level = new() { Id = 1},
                Technology = new() { Id = 1},

            },

            new QuestionResponse
            {
                Id = 30,
                Content = "What is the capital of France?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 1, Content = "Paris", isCorrect = true },
                    new Response_Response { Id = 2, Content = "Berlin", isCorrect = false }
                },
                Level = new() { Id = 1},
                Technology = new() { Id = 1},

            },

            new QuestionResponse
            {
                Id = 31,
                Content = "What is the capital of France?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 1, Content = "Paris", isCorrect = true },
                    new Response_Response { Id = 2, Content = "Berlin", isCorrect = false }
                },
                Level = new() { Id = 1},
                Technology = new() { Id = 1},

            },
            //30
            new QuestionResponse
            {
                Id = 32,
                Content = "What is the capital of France?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 1, Content = "Paris", isCorrect = true },
                    new Response_Response { Id = 2, Content = "Berlin", isCorrect = false }
                },
                Level = new() { Id = 2},
                Technology = new() { Id = 1},

            },

            new QuestionResponse
            {
                Id = 33,
                Content = "What is the primary programming language used for Android app development?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 101, Content = "Java", isCorrect = true },
                    new Response_Response { Id = 102, Content = "Swift", isCorrect = false }
                },
                Level = new() { Id = 2},
                Technology = new() { Id = 1},
            },

            new QuestionResponse
            {
                Id = 34,
                Content = "Which language runs on the Node.js runtime?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 2,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 103, Content = "JavaScript", isCorrect = true },
                    new Response_Response { Id = 104, Content = "Python", isCorrect = false }
                },
                Level = new() { Id = 2},
                Technology = new() { Id = 1},
            },

            new QuestionResponse
            {
                Id = 35,
                Content = "What does HTML stand for?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 3,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 105, Content = "HyperText Markup Language", isCorrect = true },
                    new Response_Response { Id = 106, Content = "HyperText Markdown Language", isCorrect = false }
                },
                Level = new() { Id = 2},
                Technology = new() { Id = 1},
            },

            new QuestionResponse
            {
                Id = 36,
                Content = "What is the use of 'git push' command?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 4,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 107, Content = "Uploads local repository content to a remote repository", isCorrect = true },
                    new Response_Response { Id = 108, Content = "Download content from a remote repository", isCorrect = false }
                },
                Level = new() { Id = 2},
                Technology = new() { Id = 1},
            },

            new QuestionResponse
            {
                Id = 37,
                Content = "Which of the following is a Python web framework?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 5,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 109, Content = "Django", isCorrect = true },
                    new Response_Response { Id = 110, Content = "React", isCorrect = false }
                },
                Level = new() { Id = 2},
                Technology = new() { Id = 1},
            },

            new QuestionResponse
            {
                Id = 38,
                Content = "Which data structure uses LIFO?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 6,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 111, Content = "Stack", isCorrect = true },
                    new Response_Response { Id = 112, Content = "Queue", isCorrect = false }
                },
                Level = new() { Id = 2},
                Technology = new() { Id = 1},
            },

            new QuestionResponse
            {
                Id = 39,
                Content = "What is the purpose of CSS in web development?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 7,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 113, Content = "To style web pages", isCorrect = true },
                    new Response_Response { Id = 114, Content = "To add functionality to web pages", isCorrect = false }
                },
                Level = new() { Id = 2},
                Technology = new() { Id = 1},
            },

            new QuestionResponse
            {
                Id = 40,
                Content = "What does 'MVC' stand for in software architecture?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 8,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 115, Content = "Model View Controller", isCorrect = true },
                    new Response_Response { Id = 116, Content = "Model View Compiler", isCorrect = false }
                },
                Level = new() { Id = 2},
                Technology = new() { Id = 1},
            },

            new QuestionResponse
            {
                Id = 41,
                Content = "Which protocol is primarily used for sending email?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 9,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 117, Content = "SMTP", isCorrect = true },
                    new Response_Response { Id = 118, Content = "HTTP", isCorrect = false }
                },
                Level = new() { Id = 2},
                Technology = new() { Id = 1},
            },

            new QuestionResponse
            {
                Id = 42,
                Content = "What is the main use of TypeScript?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 10,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 119, Content = "To provide types to JavaScript", isCorrect = true },
                    new Response_Response { Id = 120, Content = "To compile JavaScript to machine code", isCorrect = false }
                },
                Level = new() { Id = 2},
                Technology = new() { Id = 1},
            },
            new QuestionResponse
            {
                Id = 43,
                Content = "What does the 'public' keyword denote in C#?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 11,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 121, Content = "Access is not restricted", isCorrect = true },
                    new Response_Response { Id = 122, Content = "Access is restricted to the containing class", isCorrect = false }
                },
                Level = new() { Id = 2},
                Technology = new() { Id = 1},
            },
            new QuestionResponse
            {
                Id = 44,
                Content = "What is a primary feature of object-oriented programming?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 12,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 123, Content = "Encapsulation", isCorrect = true },
                    new Response_Response { Id = 124, Content = "Sequential execution", isCorrect = false }
                },
                Level = new() { Id = 2},
                Technology = new() { Id = 1},
            },
            new QuestionResponse
            {
                Id = 45,
                Content = "Which language runs on the JVM?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 13,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 125, Content = "Java", isCorrect = true },
                    new Response_Response { Id = 126, Content = "C++", isCorrect = false }
                },
                Level = new() { Id = 2},
                Technology = new() { Id = 1},
            },
            new QuestionResponse
            {
                Id = 46,
                Content = "What is the use of the 'await' keyword in C#?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 14,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 127, Content = "It is used to suspend the calling method until the awaited task completes", isCorrect = true },
                    new Response_Response { Id = 128, Content = "It is used to declare a variable", isCorrect = false }
                },
                Level = new() { Id = 2},
                Technology = new() { Id = 1},
            },
            new QuestionResponse
            {
                Id = 47,
                Content = "What does 'REST' stand for in web development?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 15,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 129, Content = "Representational State Transfer", isCorrect = true },
                    new Response_Response { Id = 130, Content = "Real-time Standard Transfer", isCorrect = false }
                },
                Level = new() { Id = 2},
                Technology = new() { Id = 1},
            },
            new QuestionResponse
            {
                Id = 48,
                Content = "What is the purpose of the 'var' keyword in JavaScript?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 16,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 131, Content = "Declares a variable", isCorrect = true },
                    new Response_Response { Id = 132, Content = "Declares a constant", isCorrect = false }
                },
                Level = new() { Id = 2},
                Technology = new() { Id = 1},
            },
            new QuestionResponse
            {
                Id = 49,
                Content = "Which HTML element is used to define important text?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 17,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 133, Content = "<strong>", isCorrect = true },
                    new Response_Response { Id = 134, Content = "<footer>", isCorrect = false }
                },
                Level = new() { Id = 2},
                Technology = new() { Id = 1},
            },
            new QuestionResponse
            {
                Id = 50,
                Content = "What is the result of '2' + 2 in JavaScript?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 18,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 135, Content = "'22'", isCorrect = true },
                    new Response_Response { Id = 136, Content = "4", isCorrect = false }
                },
                Level = new() { Id = 2},
                Technology = new() { Id = 1},
            },
            new QuestionResponse
            {
                Id = 51,
                Content = "Which CSS property controls the text size?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 19,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 1, Content = "Paris", isCorrect = true },
                    new Response_Response { Id = 2, Content = "Berlin", isCorrect = false }
                },
                Level = new() { Id = 2},
                Technology = new() { Id = 1},

            },

            new QuestionResponse
            {
                Id = 52,
                Content = "What is the default access modifier for a class in C#?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 20,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 137, Content = "Internal", isCorrect = true },
                    new Response_Response { Id = 138, Content = "Public", isCorrect = false }
                },
                Level = new() { Id = 2},
                Technology = new() { Id = 1},
            },

            new QuestionResponse
            {
                Id = 53,
                Content = "Which method is used to write formatted data to a stream in C#?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 21,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 139, Content = "WriteFormat", isCorrect = false },
                    new Response_Response { Id = 140, Content = "WriteLine", isCorrect = true }
                },
                Level = new() { Id = 2},
                Technology = new() { Id = 1},
            },

            new QuestionResponse
            {
                Id = 54,
                Content = "What does the 'var' keyword in JavaScript declare?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 22,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 141, Content = "A variable", isCorrect = true },
                    new Response_Response { Id = 142, Content = "A constant", isCorrect = false }
                },
                Level = new() { Id = 2},
                Technology = new() { Id = 1},
            },

            new QuestionResponse
            {
                Id = 55,
                Content = "What is the purpose of the 'async' keyword in JavaScript?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 23,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 143, Content = "Starts a new thread", isCorrect = false },
                    new Response_Response { Id = 144, Content = "Makes a function asynchronous", isCorrect = true }
                },
                Level = new() { Id = 2},
                Technology = new() { Id = 1},
            },

            new QuestionResponse
            {
                Id = 56,
                Content = "Which HTML tag is used to define an internal style sheet?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 24,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 145, Content = "<style>", isCorrect = true },
                    new Response_Response { Id = 146, Content = "<script>", isCorrect = false }
                },
                Level = new() { Id = 2},
                Technology = new() { Id = 1},
            },

            new QuestionResponse
            {
                Id = 57,
                Content = "What property in CSS is used to change the text color of an element?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 25,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 147, Content = "color", isCorrect = true },
                    new Response_Response { Id = 148, Content = "font-color", isCorrect = false }
                },
                Level = new() { Id = 2},
                Technology = new() { Id = 1},
            },

            new QuestionResponse
            {
                Id = 58,
                Content = "Which JavaScript method is used to access an element by its ID?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 26,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 149, Content = "getElementById", isCorrect = true },
                    new Response_Response { Id = 150, Content = "querySelector", isCorrect = false }
                },
                Level = new() { Id = 2},
                Technology = new() { Id = 1},
            },

            new QuestionResponse
            {
                Id = 59,
                Content = "What is the purpose of the 'this' keyword in JavaScript?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 27,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 151, Content = "Refers to the current object", isCorrect = true },
                    new Response_Response { Id = 152, Content = "Declares a new variable", isCorrect = false }
                },
                Level = new() { Id = 2},
                Technology = new() { Id = 1},

            },
             //30 lvl 2
            new QuestionResponse
            {
                Id = 1,
                Content = "What is the capital of France?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 1, Content = "Paris", isCorrect = true },
                    new Response_Response { Id = 2, Content = "Berlin", isCorrect = false }
                },
                Level = new() { Id = 3},
                Technology = new() { Id = 1},

            },

            new QuestionResponse
            {
                Id = 1,
                Content = "What is the capital of France?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 1,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 1, Content = "Paris", isCorrect = true },
                    new Response_Response { Id = 2, Content = "Berlin", isCorrect = false }
                },
                Level = new() { Id = 3},
                Technology = new() { Id = 1},

            },

            new QuestionResponse
            {
                Id = 60,
                Content = "Which attribute is used in HTML to specify an alternate text for an image, if the image cannot be displayed?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 28,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 153, Content = "alt", isCorrect = true },
                    new Response_Response { Id = 154, Content = "src", isCorrect = false }
                },
                Level = new() { Id = 2},
                Technology = new() { Id = 1},
            },

            new QuestionResponse
            {
                Id = 61,
                Content = "What does CSS stand for?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 29,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 155, Content = "Cascading Style Sheets", isCorrect = true },
                    new Response_Response { Id = 156, Content = "Computer Style Sheets", isCorrect = false }
                },
                Level = new() { Id = 2},
                Technology = new() { Id = 1},
            },

            new QuestionResponse
            {
                Id = 62,
                Content = "What is the main function of the 'var' keyword in JavaScript?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 30,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 157, Content = "Declares a variable", isCorrect = true },
                    new Response_Response { Id = 158, Content = "Declares a constant", isCorrect = false }
                },
                Level = new() { Id = 3},
                Technology = new() { Id = 1},
            },

            new QuestionResponse
            {
                Id = 63,
                Content = "Which method in C# is used to compare two strings?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 31,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 159, Content = ".Equals()", isCorrect = true },
                    new Response_Response { Id = 160, Content = ".CompareTo()", isCorrect = false }
                },
                Level = new() { Id = 3},
                Technology = new() { Id = 1},
            },

            new QuestionResponse
            {
                Id = 64,
                Content = "What does 'MVC' stand for in software architecture?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 32,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 161, Content = "Model View Controller", isCorrect = true },
                    new Response_Response { Id = 162, Content = "Model View Compiler", isCorrect = false }
                },
                Level = new() { Id = 3},
                Technology = new() { Id = 1},
            },

            new QuestionResponse
            {
                Id = 65,
                Content = "What is the purpose of the 'async' keyword in C#?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 33,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 163, Content = "Marks a method that can run asynchronously", isCorrect = true },
                    new Response_Response { Id = 164, Content = "Declares a new thread", isCorrect = false }
                },
                Level = new() { Id = 3},
                Technology = new() { Id = 1},
            },

            new QuestionResponse
            {
                Id = 66,
                Content = "Which HTML tag is used to define an internal style sheet?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 34,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 165, Content = "<style>", isCorrect = true },
                    new Response_Response { Id = 166, Content = "<script>", isCorrect = false }
                },
                Level = new() { Id = 3},
                Technology = new() { Id = 1},
            },

            new QuestionResponse
            {
                Id = 68,
                Content = "What keyword is used to declare a variable in JavaScript?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 36,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 169, Content = "var", isCorrect = true },
                    new Response_Response { Id = 170, Content = "variable", isCorrect = false }
                },
                Level = new() { Id = 3},
                Technology = new() { Id = 1},
            },
            new QuestionResponse
            {
                Id = 69,
                Content = "What is the default access modifier in C#?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 37,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 171, Content = "Private", isCorrect = true },
                    new Response_Response { Id = 172, Content = "Public", isCorrect = false }
                },
                Level = new() { Id = 3},
                Technology = new() { Id = 1},
            },
            new QuestionResponse
            {
                Id = 70,
                Content = "Which method in Python is used to add an item to the end of a list?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 38,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 173, Content = "append()", isCorrect = true },
                    new Response_Response { Id = 174, Content = "add()", isCorrect = false }
                },
                Level = new() { Id = 3},
                Technology = new() { Id = 1},
            },
            new QuestionResponse
            {
                Id = 71,
                Content = "What does the 'static' keyword denote in Java?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 39,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 175, Content = "Belongs to the class, not instances", isCorrect = true },
                    new Response_Response { Id = 176, Content = "Instance initialization", isCorrect = false }
                },
                Level = new() { Id = 3},
                Technology = new() { Id = 1},
            },
            new QuestionResponse
            {
                Id = 72,
                Content = "Which HTML element is used for the largest heading?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 40,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 177, Content = "<h1>", isCorrect = true },
                    new Response_Response { Id = 178, Content = "<h6>", isCorrect = false }
                },
                Level = new() { Id = 3},
                Technology = new() { Id = 1},
            },
            new QuestionResponse
            {
                Id = 73,
                Content = "What property in CSS is used to change the text color of an element?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 41,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 179, Content = "color", isCorrect = true },
                    new Response_Response { Id = 180, Content = "font-color", isCorrect = false }
                },
                Level = new() { Id = 3},
                Technology = new() { Id = 1},
            },
            new QuestionResponse
            {
                Id = 74,
                Content = "What is the purpose of the 'super' keyword in Java?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 42,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 181, Content = "To call superclass methods", isCorrect = true },
                    new Response_Response { Id = 182, Content = "To call current class methods", isCorrect = false }
                },
                Level = new() { Id = 3},
                Technology = new() { Id = 1},
            },
            new QuestionResponse
            {
                Id = 75,
                Content = "Which SQL statement is used to extract data from a database?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 43,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 183, Content = "SELECT", isCorrect = true },
                    new Response_Response { Id = 184, Content = "EXTRACT", isCorrect = false }
                },
                Level = new() { Id = 3},
                Technology = new() { Id = 1},
            },
            new QuestionResponse
            {
                Id = 76,
                Content = "What is the command to install a package in Node.js?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 44,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 185, Content = "npm install", isCorrect = true },
                    new Response_Response { Id = 186, Content = "node install", isCorrect = false }
                },
                Level = new() { Id = 3},
                Technology = new() { Id = 1},
            },
            new QuestionResponse
            {
                Id = 77,
                Content = "What does 'CSS' stand for?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 45,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 187, Content = "Cascading Style Sheets", isCorrect = true },
                    new Response_Response { Id = 188, Content = "Colorful Style Sheets", isCorrect = false }
                },
                Level = new() { Id = 3},
                Technology = new() { Id = 1},
            },
            new QuestionResponse
            {
                Id = 78,
                Content = "What HTML attribute specifies an alternate text for an image, if the image cannot be displayed?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 46,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 189, Content = "alt", isCorrect = true },
                    new Response_Response { Id = 190, Content = "src", isCorrect = false }
                },
                Level = new() { Id = 3},
                Technology = new() { Id = 1},
            },
            new QuestionResponse
            {
                Id = 79,
                Content = "Which JavaScript method is used to write text to the document?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 47,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 191, Content = "document.write()", isCorrect = true },
                    new Response_Response { Id = 192, Content = "console.log()", isCorrect = false }
                },
                Level = new() { Id = 3},
                Technology = new() { Id = 1},
            },
            new QuestionResponse
            {
                Id = 80,
                Content = "What is the correct syntax for referring to an external script called 'xxx.js'?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 48,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 193, Content = "<script src='xxx.js'>", isCorrect = true },
                    new Response_Response { Id = 194, Content = "<script href='xxx.js'>", isCorrect = false }
                },
                Level = new() { Id = 3},
                Technology = new() { Id = 1},
            },
            new QuestionResponse
            {
                Id = 81,
                Content = "Which attribute is used to specify that an input field must be filled out?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 49,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 195, Content = "required", isCorrect = true },
                    new Response_Response { Id = 196, Content = "placeholder", isCorrect = false }
                },
                Level = new() { Id = 3},
                Technology = new() { Id = 1},
            },
            new QuestionResponse
            {
                Id = 82,
                Content = "What does the 'this' keyword refer to in JavaScript?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 50,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 197, Content = "The current object", isCorrect = true },
                    new Response_Response { Id = 198, Content = "The global object", isCorrect = false }
                },
                Level = new() { Id = 3},
                Technology = new() { Id = 1},
            },
            new QuestionResponse
            {
                Id = 83,
                Content = "What is the purpose of the 'break' statement in programming?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 51,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 199, Content = "Exits a loop or switch statement", isCorrect = true },
                    new Response_Response { Id = 200, Content = "Pauses the execution of a loop", isCorrect = false }
                },
                Level = new() { Id = 3},
                Technology = new() { Id = 1},
            },
            new QuestionResponse
            {
                Id = 84,
                Content = "Which data type is used to create a variable that should store text?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 52,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 201, Content = "String", isCorrect = true },
                    new Response_Response { Id = 202, Content = "Text", isCorrect = false }
                },
                Level = new() { Id = 3},
                Technology = new() { Id = 1},
            },
            new QuestionResponse
            {
                Id = 85,
                Content = "What is the correct HTML element for inserting a line break?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 53,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 203, Content = "<br>", isCorrect = true },
                    new Response_Response { Id = 204, Content = "<lb>", isCorrect = false }
                },
                Level = new() { Id = 3},
                Technology = new() { Id = 1},
            },
            new QuestionResponse
            {
                Id = 86,
                Content = "What is the correct way to comment out a line in HTML?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 54,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 205, Content = "<!-- This is a comment -->", isCorrect = true },
                    new Response_Response { Id = 206, Content = "// This is a comment", isCorrect = false }
                },
                Level = new() { Id = 3},
                Technology = new() { Id = 1},
            },
            new QuestionResponse
            {
                Id = 87,
                Content = "Which operator is used to assign a value to a variable in JavaScript?",
                Type = "MultipleChoice",
                IsValid = true,
                Order = 55,
                Response = new List<Response_Response>
                {
                    new Response_Response { Id = 207, Content = "=", isCorrect = true },
                    new Response_Response { Id = 208, Content = "==", isCorrect = false }
                },
                Level = new() { Id = 3},
                Technology = new() { Id = 1},
            }

            //10 lvl3 
        };

        public static List<Quizz_QuestionResponse> quizz_QuestionResponses = new List<Quizz_QuestionResponse>
        {
            new Quizz_QuestionResponse
            {
                QuestionId = 1,
                QuizId = 1,
            },
            new Quizz_QuestionResponse
            {
                QuestionId = 2,
                QuizId = 1,
            },
            new Quizz_QuestionResponse
            {
                QuestionId = 3,
                QuizId = 1,
            },
            new Quizz_QuestionResponse
            {
                QuestionId = 4,
                QuizId = 1,
            },
            new Quizz_QuestionResponse
            {
                QuestionId = 5,
                QuizId = 1,
            },
            new Quizz_QuestionResponse
            {
                QuestionId = 6,
                QuizId = 1,
            },
            new Quizz_QuestionResponse
            {
                QuestionId = 7,
                QuizId = 1,
            },
        };
    }
}
