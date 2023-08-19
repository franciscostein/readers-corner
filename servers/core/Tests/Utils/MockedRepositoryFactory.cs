using Moq;
using ReadersCorner.Core.Models;
using ReadersCorner.Core.Repositories;
using ReadersCorner.Core.Repositories.Interfaces;
using ReadersCorner.Core.Services;

namespace ReadersCorner.Core.Tests.Utils
{
    public class MockedRepositoryFactory<TModel> where TModel : class
    {
        private readonly Mock<IRepository<TModel>> _mockRepository;

        public MockedRepositoryFactory()
        {
            _mockRepository = new Mock<IRepository<TModel>>();
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
                case Method.Update:
                    _mockRepository.Setup(repo => repo.Update((TModel)input)).Returns((TModel)expectedReturn);
                    break;
                case Method.Delete:
                    _mockRepository.Setup(repo => repo.Delete((int)input)).Returns((bool)expectedReturn);
                    break;
            }

            if (typeof(TModel) == typeof(Book))
            {
                var service = new BookService((BookRepository)_mockRepository.Object);
                return new MockedRepository<TModel>(_mockRepository, service);
            }
            else if (typeof(TModel) == typeof(Author))
            {
                var service = new AuthorService((AuthorRepository)_mockRepository.Object);
                return new MockedRepository<TModel>(_mockRepository, service);
            }

            return new MockedRepository<TModel>();
        }
    }

    public class MockedRepository<TModel>
    {
        public MockedRepository()
        {
        }

        public MockedRepository(Mock<IRepository<TModel>> repository, BookService service)
        {
            Repository = repository;
            BookService = service;
        }

        public MockedRepository(Mock<IRepository<TModel>> repository, AuthorService service)
        {
            Repository = repository;
            AuthorService = service;
        }

        public Mock<IRepository<TModel>> Repository { get; }
        public BookService BookService { get; }
        public AuthorService AuthorService { get; }
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
