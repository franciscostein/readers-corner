using ReadersCorner.Core.Models;
using ReadersCorner.Core.Tests.Utils;

namespace ReadersCorner.Core.Tests.Services
{
    public class UserServiceTests
    {
        private readonly MockedRepositoryFactory<User> _mockedRepository;

        public UserServiceTests()
        {
            _mockedRepository = new MockedRepositoryFactory<User>();
        }
    }
}