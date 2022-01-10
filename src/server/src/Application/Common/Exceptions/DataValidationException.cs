﻿using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace GitNode.Application.Common.Exceptions
{
    public class DataValidationException : Exception
    {
        public DataValidationException() : base("One or more validation failures have occurred.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public DataValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

        public IDictionary<string, string[]> Errors { get; }
    }
}