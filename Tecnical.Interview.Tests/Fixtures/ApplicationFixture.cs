using Ardalis.Specification;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technical.Interview.WebApi;
using Technical.Interview.WebApi.Entities;
using Technical.Interview.WebApi.Services;

namespace Tecnical.Interview.Tests.Fixtures
{
    public class ApplicationFixture
    {
        #region Public Fields

        public readonly Mock<IUnitOfWork> _unitOfWorkMock;
        public readonly Mock<IReadRepository<MarcasAuto>> _readMarcasAuto;
        public readonly Mock<IRepository<MarcasAuto>> _marcasAutoRepository;
        public readonly Mock<IBrandService> _brandService;
        public readonly Mock<ISingleResultSpecification<MarcasAuto>> _singleResultSpecification;
        #endregion Public Fields

        #region Public Constructors

        public ApplicationFixture()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _readMarcasAuto = new Mock<IReadRepository<MarcasAuto>>();
            _marcasAutoRepository = new Mock<IRepository<MarcasAuto>>();
            _brandService = new Mock<IBrandService>();
            _singleResultSpecification = new Mock<ISingleResultSpecification<MarcasAuto>>();
        }

        #endregion Public Constructors
    }
}
