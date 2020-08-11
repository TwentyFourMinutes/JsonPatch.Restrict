using JsonPatch.Restrict.Tests.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using Xunit;

namespace JsonPatch.Restrict.Tests
{
    public class RestrictionTests
    {
        [Fact]
        public void ApplyRestrictedPath()
        {
            var dummy = new DummyModel
            {
                Id = 1,
                Value = "baseValue",
            };

            GetPatchDocument().ApplyToWithRestrictions(dummy, "Value");

            Assert.Equal(1, dummy.Id);
            Assert.Equal("newValue", dummy.Value);
        }

        [Fact]
        public void TryApplyRestrictedPath()
        {
            var dummy = new DummyModel
            {
                Id = 1,
                Value = "baseValue",
            };

            Assert.True(GetPatchDocument().TryApplyToWithRestrictions(dummy, out _, "Value"));

            Assert.Equal(1, dummy.Id);
            Assert.Equal("newValue", dummy.Value);
        }

        [Fact]
        public void TryApplyIllegalRestrictedPath()
        {
            var dummy = new DummyModel
            {
                Id = 1,
                Value = "baseValue",
            };

            Assert.False(GetPatchDocument().TryApplyToWithRestrictions(dummy, out var error));

            Assert.NotNull(error);

            Assert.Equal(1, dummy.Id);
            Assert.Equal("baseValue", dummy.Value);
        }

        [Fact]
        public void ApplyIllegalRestrictedPath()
        {
            var dummy = new DummyModel
            {
                Id = 1,
                Value = "baseValue",
            };

            JsonPatchError? error = default;

            GetPatchDocument().ApplyToWithRestrictions(dummy, e => error = e);

            Assert.NotNull(error);

            Assert.Equal(1, dummy.Id);
            Assert.Equal("baseValue", dummy.Value);
        }

        private JsonPatchDocument GetPatchDocument()
        {
            var patchDocument = new JsonPatchDocument();

            patchDocument.Replace("/Value", "newValue");

            return patchDocument;
        }
    }
}
