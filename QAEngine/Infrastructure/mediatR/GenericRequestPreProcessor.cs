using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR.Pipeline;
using System.IO;
using System.Threading;

namespace QAEngine.Web.Infrastructure.mediatR
{
    public class GenericRequestPreProcessor<TRequest> : IRequestPreProcessor<TRequest>
    {
        

        private readonly TextWriter _writer;

        public GenericRequestPreProcessor(TextWriter writer)
        {
            _writer = writer;
        }


        public Task Process (TRequest request, CancellationToken cancellationToken)
        {
            return _writer.WriteLineAsync("--- Starting Up");
        }

    }
}
