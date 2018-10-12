﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace QAEngine.Web.Infrastructure.mediatR
{
    public class GenericPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly TextWriter _writer;

        public GenericPipelineBehavior(TextWriter writer)
        {
            _writer = writer;
        }


        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            await _writer.WriteLineAsync("--- Handling Request");
            var response = await next();
            await _writer.WriteLineAsync("--- Finished Request");
            return response;
        }
    }
}
