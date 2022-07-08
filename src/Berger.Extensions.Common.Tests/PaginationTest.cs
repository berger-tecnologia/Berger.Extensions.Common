using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;
using Berger.Extensions.Common.Pagination;

namespace Berger.Extensions.Common.Tests
{
    public class PaginationTest
    {
        private const int TotalCount = 100;
        private const int Pages = 5;
        private const int Limit = TotalCount / Pages;
        private IList<string> StringList = new string[TotalCount].ToList();

        [Test]
        [Order(0)]
        public void ShouldPaginate()
        {
            var pagination = StringList.Paginate(1, Limit);

            Assert.IsTrue(pagination.Pages == Pages);
            Assert.IsTrue(pagination.Items.Count == Limit);
            Assert.IsTrue(pagination.TotalCount == TotalCount);
            Assert.IsTrue(pagination.Limit == Limit);
        }

        [Test]
        [Order(1)]
        public void ShouldHaveNextPage()
        {
            var pagination = StringList.Paginate(1, Limit);

            Assert.IsTrue(pagination.PageInfo.HasNextPage);
        }

        [Test]
        [Order(2)]
        public void ShouldNotHaveNextPage()
        {
            var pagination = StringList.Paginate(5, Limit);

            Assert.IsTrue(!pagination.PageInfo.HasNextPage);
        }

        [Test]
        [Order(3)]
        public void ShouldHavePreviousPage()
        {
            var pagination = StringList.Paginate(2, Limit);

            Assert.IsTrue(pagination.PageInfo.HasPreviousPage);
        }
        [Test]
        [Order(4)]
        public void ShouldNotHavePreviousPage()
        {
            var pagination = StringList.Paginate(1, Limit);

            Assert.IsTrue(!pagination.PageInfo.HasPreviousPage);
        }
    }
}
