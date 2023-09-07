using Moq;
using ReadersCorner.Core.Models;
using ReadersCorner.Core.Repositories.Interfaces;
using ReadersCorner.Core.Services;
using ReadersCorner.Core.Services.Interfaces;

namespace ReadersCorner.Core.Tests.Utils
{
    public class MockedRepositoryFactory<TModel> where TModel : class
    {
        private Mock<IRepository<TModel>> _mockRepository;

        public MockedRepositoryFactory()
        {
            _mockRepository = new Mock<IRepository<TModel>>();

            if (typeof(TModel) == typeof(Book))
            {
                var bookRepositoryMock = new Mock<IBookRepository>();
                _mockRepository = bookRepositoryMock.As<IRepository<TModel>>();
            }
            else if (typeof(TModel) == typeof(Author))
            {
                var authorRepositoryMock = new Mock<IAuthorRepository>();
                _mockRepository = authorRepositoryMock.As<IRepository<TModel>>();
            }
            else if (typeof(TModel) == typeof(User))
            {
                var userRepositoryMock = new Mock<IUserRepository>();
                _mockRepository = userRepositoryMock.As<IRepository<TModel>>();
            }
        }

        public MockedRepository<TModel> Create(Method method, object input, object expectedReturn)
        {
            switch (method)
            {
                case Method.GetById:
                    _mockRepository.Setup(repo => repo.GetById((int)input)).Returns((TModel)expectedReturn);
                    break;
                case Method.GetAll:
                    _mockRepository.Setup(repo => repo.GetAll()).Returns((List<TModel>)expectedReturn);
                    break;
                case Method.Add:
                    _mockRepository.Setup(repo => repo.Add((TModel)input)).Returns((TModel)expectedReturn);
                    break;
            }

            return GetMockedRepository();
        }

        public MockedRepository<TModel> Create(Method method, object getInput, object getReturn, object operationInput, object expectedReturn)
        {
            _mockRepository.Setup(repo => repo.GetById((int)getInput)).Returns((TModel)getReturn);

            switch (method)
            {
                case Method.Update:
                    _mockRepository.Setup(repo => repo.Update((TModel)operationInput)).Returns((TModel)expectedReturn);
                    break;
                case Method.Delete:
                    _mockRepository.Setup(repo => repo.Delete((TModel)operationInput)).Returns((bool)expectedReturn);
                    break;
            }

            return GetMockedRepository();
        }

        private MockedRepository<TModel> GetMockedRepository()
        {
            if (typeof(TModel) == typeof(Book))
            {
                var service = new BookService((IBookRepository)_mockRepository.Object);
                return new MockedRepository<TModel>(_mockRepository, service);
            }
            else if (typeof(TModel) == typeof(Author))
            {
                var service = new AuthorService((IAuthorRepository)_mockRepository.Object);
                return new MockedRepository<TModel>(_mockRepository, service);
            }
            else if (typeof(TModel) == typeof(User))
            {
                var service = new UserService((IUserRepository)_mockRepository.Object);
                return new MockedRepository<TModel>(_mockRepository, service);
            }

            return new MockedRepository<TModel>();
        }
    }

    public class MockedRepository<TModel>
    {
        public MockedRepository() { }

        public MockedRepository(Mock<IRepository<TModel>> repository, IBookService service)
        {
            Repository = repository;
            BookService = service;
        }

        public MockedRepository(Mock<IRepository<TModel>> repository, IAuthorService service)
        {
            Repository = repository;
            AuthorService = service;
        }

        public MockedRepository(Mock<IRepository<TModel>> repository, IUserService service)
        {
            Repository = repository;
            UserService = service;
        }

        public Mock<IRepository<TModel>> Repository { get; }
        public IBookService BookService { get; }
        public IAuthorService AuthorService { get; }
        public IUserService UserService { get; }
    }

    public enum Method
    {
        GetById,
        GetAll,
        Add,
        Update,
        Delete
    }
}
