using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkShortener.BusinessLogic.Services;
using LinkShortener.Common.DI.IRepositories;
using LinkShortener.Common.Entities;
using LinkShortener.Common.Validation;
using Moq;
using NUnit.Framework;

namespace LinkShortener.BusinessLogic.UnitTests
{
    public class ShortUrlServiceTests
    {
        private static readonly Mock<IShortUrlRepository> _shortUrlRepository = new () { CallBase = true };
        private readonly ShortUrlService _shortUrlService = new (_shortUrlRepository.Object);
        private readonly List<ShortUrl> _expectedShortUrls =
        [
            new ShortUrl(1, "http://google.com/sadfasdfaescsdgge/dvasd/afc", "http://google.com/sadfasdfa", DateTimeOffset.Now, 2),
            new ShortUrl(2, "http://google.com/sadfasdfaescregergergrtgsdgge/dvasd/afc", "http://google.com/dfsff", DateTimeOffset.Now, 4),
        ];
        private int _timesApplyRuleCalled;

        [SetUp]
        protected void SetUp()
        {
            _shortUrlRepository.Setup(x => x.InsertAsync(It.IsAny<ShortUrl>())).Callback(() => _timesApplyRuleCalled++);
            _shortUrlRepository.Setup(x => x.UpdateAsync(It.IsAny<ShortUrl>())).Callback(() => _timesApplyRuleCalled++);
            _shortUrlRepository.Setup(x => x.DeleteAsync(It.IsAny<int>())).Callback(() => _timesApplyRuleCalled++);
            _shortUrlRepository.Setup(x => x.GetAll()).Returns(_expectedShortUrls.AsQueryable());
            _shortUrlRepository.Setup(x => x.InsertNewUrlAsync(It.IsAny<string>())).Callback(() => _timesApplyRuleCalled++);
            _shortUrlRepository.Setup(x => x.UpdateOnlyUrlAsync(It.IsAny<int>(), It.IsAny<string>())).Callback(() => _timesApplyRuleCalled++);
            _shortUrlRepository.Setup(x => x.IncrementCounterAsync(It.IsAny<int>())).Callback(() => _timesApplyRuleCalled++);
            foreach (var shrtUrl in _expectedShortUrls)
            {
                _shortUrlRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(_expectedShortUrls[shrtUrl.Id - 1]);
            }
        }

        [Test]
        public void Validate_WhenWrongUrl_ShouldTrow()
        {
            // arrange
            var shortUrlExpected = new ShortUrl
            {
                Url = "dsdfsdfsdfs",
                TinyUrl = _expectedShortUrls[0].TinyUrl,
                Date = _expectedShortUrls[0].Date,
                Counter = _expectedShortUrls[0].Counter,
            };
            var strException =
                "This 'Url' has wrong format!";

            // act
            var actualException = Assert.ThrowsAsync<ValidationException>(
                            async () => await _shortUrlService.ValidateAsync(shortUrlExpected));

            // assert
            Assert.That(actualException.Message, Is.EqualTo(strException));
        }

        [Test]
        public void Validate_WhenShortUrlFieldUrlEmpty_ShouldThrow()
        {
            // arrange
            var shortUrlExpected = new ShortUrl
            {
                Url = string.Empty,
                TinyUrl = _expectedShortUrls[0].TinyUrl,
                Date = _expectedShortUrls[0].Date,
                Counter = _expectedShortUrls[0].Counter,
            };
            var strException =
                "The field 'Url' of ShortUrl is not allowed to be empty!";

            // act
            var actualException = Assert.ThrowsAsync<ValidationException>(
                            async () => await _shortUrlService.ValidateAsync(shortUrlExpected));

            // assert
            Assert.That(actualException.Message, Is.EqualTo(strException));
        }

        [Test]
        public async Task Insert_WhenCallInsertUrl_ShouldNotZeroCallback()
        {
            // arrange
            var shortUrlExpected = new ShortUrl(1, "https://www.google.by/search?q=jjkbvg", "https://google.com/sadfasdfa", DateTimeOffset.Now, 2);

            // act
            await _shortUrlService.InsertAsync(shortUrlExpected);

            // assert
            Assert.That(_timesApplyRuleCalled, Is.Not.Zero);
            _timesApplyRuleCalled = default;
        }

        [Test]
        public async Task Update_WhenCallUpdateUrl_ShouldNotZeroCallback()
        {
            // arrange
            var shortUrlExpected = new ShortUrl(1, "https://google.com/sadfasdfaescsdgge/dvasd/afc", "https://google.com/sadfasdfa", DateTimeOffset.Now, 2);

            // act
            await _shortUrlService.UpdateAsync(shortUrlExpected);

            // assert
            Assert.That(_timesApplyRuleCalled, Is.Not.Zero);
            _timesApplyRuleCalled = default;
        }

        [Test]
        public async Task Delete_WhenCallDeleteUrl_ShouldNotZeroCallback()
        {
            // act
            await _shortUrlService.DeleteAsync(1);

            // assert
            Assert.That(_timesApplyRuleCalled, Is.Not.Zero);
            _timesApplyRuleCalled = default;
        }

        [Test]
        public async Task GetById_WhenReturnShortUrlById_ShouldNotNull()
        {
            // act
            var actual = await _shortUrlService.GetByIdAsync(1);

            // assert
            Assert.That(actual, Is.Not.Null);
        }

        [Test]
        public async Task GetAll_WhenReturnShortUrls_ShouldNotZero()
        {
            // act
            var actual = (await _shortUrlService.GetAllAsync()).Count();

            // assert
            Assert.That(actual, Is.Not.Zero);
        }
    }
}
