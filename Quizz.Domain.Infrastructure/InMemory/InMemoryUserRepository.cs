using Quizz.Domain.Core.Dto;
using Quizz.Domain.Core.Entities;
using Quizz.Domain.Core.Interfaces;


namespace Quizz.Domain.Infrastructure.InMemory
{
    public class InMemoryUserRepository : IUserRepository
    {
        private List<UserRequest> users;
        private List<LevelRequest> levelRequests;
        private List<TechnologiesRequest> technologiesRequests;
        private List<CandidateRequest> candidateRequests;
        private List<QuizRequest> quizRequests;
        private List<QuestionRequest> questionRequests;
        public InMemoryUserRepository()
        {
            users = GetUsers();
            levelRequests = GetLevelRequest();
            technologiesRequests = GetTechnologies();
            quizRequests = GetQuizz();
            questionRequests = GetQuestions();
            candidateRequests = GetCandidate();
        }



        public Task<bool> EmailAlreadyExist(string email)
        {
            return Task.Run(() => users.Any(f => f.EmailAddress == email));
        }

        public Task<UserResponse> GetByEmailAndPassword(LoginRequest loginRequest)
        {
            var user = users.FirstOrDefault(
                u => u.EmailAddress == loginRequest.EmailAddress
                && u.Password == loginRequest.Password
            );

            if (user == null)
            {
                return Task.FromResult<UserResponse>(null);
            }

            return Task.FromResult(new UserResponse
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                Id = user.Id,
                Token = user.Token
            });
        }

        public Task<UserResponse> Login(UserRequest userRequest)
        {
            if (userRequest == null) throw new ArgumentNullException(nameof(userRequest));
            return null;
        }

        public void UpdateToken(int? id, string token)
        {
            var users = GetUsers();
            var user = users.FirstOrDefault(u => u.Id == id);

            if (user != null && token != null)
            {
                user.Token = token;
            }
        }

        public async Task<UserResponse> Add(UserRequest request)
        {
            await Task.Run(() => users.Add(request));

            return new UserResponse()
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                EmailAddress = request.EmailAddress,
                IsActive = request.IsActive,
                Token = request.Token,
                Role = new()
                {
                    Id = (int)request.Role.Id,
                    Name = request.Role.Name,
                }
            };
        }

        public async Task<List<UserResponse>> getAll()
        {
            var usersResponse = users.Select(user => new UserResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                EmailAddress = user.EmailAddress,
                IsActive = user.IsActive,
                Token = user.Token,
                Role = new()
                {
                    Id = (int)user.Role.Id,
                    Name = user.Role.Name,
                }
            }).ToList();

            return await Task.FromResult(usersResponse);

        }

        public async Task<UserResponse> GetById(int id)
        {
            var user = await Task.Run(() => users.FirstOrDefault(l => l.Id == id));

            if (user == null)
            {
                return null;
            }
            else return new UserResponse()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                EmailAddress = user.EmailAddress,
                IsActive = user.IsActive,
                Token = user.Token,
                Role = new()
                {
                    Id = (int)user.Role.Id,
                    Name = user.Role.Name,
                },
            };
        }

        public Task<bool> Delete(UserRequest request)
        {
            return Task.Run(() =>
            {
                var itemToRemove = users.SingleOrDefault(r => r.Id == request.Id);
                if (itemToRemove != null)
                {
                    users.Remove(itemToRemove);
                    return true;
                }
                return false;
            });
        }

        public async Task<UserResponse> Update(UserRequest request)
        {
            var response = new UserResponse();

            try
            {
                await Task.Run(() =>
                {
                    lock (users)
                    {
                        int index = users.FindIndex(l => l.Id == request.Id);

                        if (index >= 0)
                        {
                            users.RemoveAt(index);
                            var updatedUser = new UserRequest()
                            {
                                Id = request.Id,
                                FirstName = request.FirstName,
                                LastName = request.LastName,
                                PhoneNumber = request.PhoneNumber,
                                EmailAddress = request.EmailAddress,
                                IsActive = request.IsActive,
                                Token = request.Token,
                                Role = request.Role
                            };
                            users.Add(updatedUser);
                            response.Id = updatedUser.Id;
                            response.FirstName = updatedUser.FirstName;
                            response.LastName = updatedUser.LastName;
                            response.PhoneNumber = updatedUser.PhoneNumber;
                            response.EmailAddress = updatedUser.EmailAddress;
                            response.IsActive = updatedUser.IsActive;
                            response.Role = new RoleResponse()
                            {
                                Id = (int)updatedUser.Role.Id,
                                Name = updatedUser.Role.Name,
                            };
                            response.Token = updatedUser.Token;

                        }
                        else
                        {
                            response.Id = -1;
                            response.FirstName = "Users not found.";
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                response.Id = -1;
                response.FirstName = $"An error occurred: {ex.Message}";
            }

            return response;
        }

        public Task<bool> UserIsUsed(UserRequest userRequest)
        {
            return Task.Run(
                () => questionRequests.Any(f => f.AdminId == userRequest.Id
                || levelRequests.Any(l => l.AdminId == userRequest.Id)
                || technologiesRequests.Any(t => t.AdminId == userRequest.Id)
                || quizRequests.Any(q => q.AdminId == userRequest.Id)
                || quizRequests.Any(q => q.AgentId == userRequest.Id)
                || candidateRequests.Any(c => c.Agent.Id == userRequest.Id)
                )
            );
        }

        public Task<bool> IdIsNotAvailable(int id)
        {
            return Task.Run(() => users.Any(f => f.Id == id));
        }

        #region Mock Data
        private List<UserRequest> GetUsers()
        {
            return new List<UserRequest> {
            new UserRequest
            {
                EmailAddress = "Junior@admin.cin",
                FirstName = "paul",
                LastName = "adm",
                Id = 1,
                Password = "amdin",
                Token = "",
                Role = new()
                {
                    Id = 1,
                    Name = "Admin"
                }
            },
            new UserRequest
            {
                EmailAddress = "Senior@admin.cin",
                FirstName = "jean",
                LastName = "test",
                Id = 2,
                Password = "test",
                Token = "",
                Role = new()
                {
                    Id = 1,
                    Name = "Admin"
                }

            },
            new UserRequest
            {
                EmailAddress = "email3@test.test",
                FirstName = "john",
                LastName = "doe",
                Id = 3,
                Password = "monpassP",
                Token = "",
                Role = new()
                {
                    Id = 1,
                    Name = "Admin"
                }
            },
            new UserRequest
            {
                EmailAddress = "email4@test.test",
                FirstName = "john",
                LastName = "doe",
                Id = 4,
                Password = "monpassP",
                Token = "",
                Role = new()
                {
                    Id = 1,
                    Name = "Admin"
                }
            },
            new UserRequest
            {
                EmailAddress = "email5@test.test",
                FirstName = "john",
                LastName = "doe",
                Id = 5,
                Password = "monpassP",
                Token = "",
                Role = new()
                {
                    Id = 2,
                    Name = "Agent"
                }
            },
            new UserRequest
            {
                EmailAddress = "email6@test.test",
                FirstName = "john",
                LastName = "doe",
                Id = 6,
                Password = "monpassP",
                Token = "",
                Role = new()
                {
                    Id = 1,
                    Name = "Admin"
                }
            },
            new UserRequest
            {
                EmailAddress = "email7@test.test",
                FirstName = "user",
                LastName = "delete",
                Id = 7,
                Password = "monpassP",
                Token = "",
                Role = new()
                {
                    Id = 2,
                    Name = "Agent"
                }
            }
            };
        }

        private List<LevelRequest> GetLevelRequest()
        {
            return new List<LevelRequest>
            {
                new LevelRequest
                {
                    Id = 0,
                    Content ="Junior",
                    AdminId = 1,
                },
                new LevelRequest
                {
                    Id = 1,
                    Content = "Senior",
                    AdminId = 2,
                },
                new LevelRequest
                {
                    Id = 2,
                    Content = "To Delete",
                    AdminId = 3,
                }
            };
        }

        private List<QuestionRequest> GetQuestions()
        {
            return new List<QuestionRequest>
            {
                new QuestionRequest
                {
                    AdminId=2,        
                },
                new QuestionRequest
                {
                    AdminId=2,
                    
                },
                new QuestionRequest
                {
                    AdminId=2,
                }
            };
        }

        private List<TechnologiesRequest> GetTechnologies()
        {
            return new List<TechnologiesRequest>
            {
                new TechnologiesRequest
                {
                     AdminId= 4,
                },
                new TechnologiesRequest
                {
                    AdminId=5,
                },
                new TechnologiesRequest
                {
                    AdminId = 6
                }
            };
        }

        private List<CandidateRequest> GetCandidate()
        {
            return new List<CandidateRequest>
            {
                new CandidateRequest
                {
                    Agent = new User()
                    {
                        Id=1,
                    }
                },
                new CandidateRequest
                {
                    Agent = new User()
                    {
                        Id=2,
                    }
                },
                new CandidateRequest
                {
                    Agent = new User()
                    {
                        Id=1,
                    },
                }
            };
        }

        private List<QuizRequest> GetQuizz()
        {
            return new List<QuizRequest>
            {
                new QuizRequest
                {
                   AgentId = 1,
                   AdminId = 6
                },
                new QuizRequest
                {
                   AgentId = 5,
                   AdminId = 2
                },
                new QuizRequest
                {
                   AgentId = 1,
                   AdminId = 4

                }
            };
        }
        #endregion
    }
}
