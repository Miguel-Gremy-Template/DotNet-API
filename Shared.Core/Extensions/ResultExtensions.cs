﻿using Shared.Core.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shared.Core.Extensions
{
	public static class ResultExtensions
	{
		public static Result<T> Ensure<T>(
			this Result<T> result,
			Func<T, bool> predicate,
			IEnumerable<string> error)
		{
			if (result.IsFailure)
			{
				return result;
			}

			return predicate(result.Value) ?
				result :
				Result<T>.Failure(error);
		}
		public static Result<T> Ensure<T>(
			this Result<T> result,
			Func<T, Task<bool>> predicate,
			IEnumerable<string> error)
		{
			if (result.IsFailure)
			{
				return result;
			}

			return predicate(result.Value).GetAwaiter().GetResult() ?
				result :
				Result<T>.Failure(error);
		}

		public static Result<T> Ensure<T>(
			this Result<T> result,
			Func<T, (bool, IEnumerable<string>)> predicate)
		{
			if (result.IsFailure)
			{
				return result;
			}

			var (isSuccess, error) = predicate(result.Value);

			return isSuccess ?
				result :
				Result<T>.Failure(error);
		}

		public static Result<T> Ensure<T>(
			this Result<T> result,
			Func<T, Task<(bool, IEnumerable<string>)>> predicate)
		{
			if (result.IsFailure)
			{
				return result;
			}

			var (isSuccess, error) = predicate(result.Value).GetAwaiter().GetResult();

			return isSuccess ?
				result :
				Result<T>.Failure(error);
		}

		public static Result<TOut> Map<TIn, TOut>(
			this Result<TIn> result,
			Func<TIn, TOut> mappingFunc)
		{
			return result.IsSuccess ?
				Result<TOut>.Success(mappingFunc(result.Value)) :
				Result<TOut>.Failure(result.Message);
		}
		public static Result<TOut> Map<TIn, TOut>(
			this Result<TIn> result,
			Func<TIn, Task<TOut>> mappingFunc)
		{
			return result.IsSuccess ?
				Result<TOut>.Success(mappingFunc(result.Value).GetAwaiter().GetResult()) :
				Result<TOut>.Failure(result.Message);
		}
	}
}
