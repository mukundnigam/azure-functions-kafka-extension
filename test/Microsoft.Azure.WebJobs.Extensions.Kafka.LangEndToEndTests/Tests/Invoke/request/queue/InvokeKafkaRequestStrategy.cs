﻿using Microsoft.Azure.WebJobs.Extensions.Kafka.LangEndToEndTests.command;
using Microsoft.Azure.WebJobs.Extensions.Kafka.LangEndToEndTests.executor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.WebJobs.Extensions.Kafka.LangEndToEndTests.Tests.Invoke.request.queue
{
    // Placeholder class for Kafka requests
    public class InvokeKafkaRequestStrategy : InvokeRequestStrategy<string>
    {
        private IExecutor<Command<string>, string> kafkaCommandExecutor;

        public InvokeKafkaRequestStrategy(string kafkaProducerRequestEntity)
        {
            
        }

        public string InvokeRequest()
        {
            // Placeholder when we need to write in kafka
            return null;
        }
    }
}
