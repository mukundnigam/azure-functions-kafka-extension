﻿using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.Kafka.LangEndToEndTests.apps.languages;
using Microsoft.Azure.WebJobs.Extensions.Kafka.LangEndToEndTests.apps.type;
using Microsoft.Azure.WebJobs.Extensions.Kafka.LangEndToEndTests.entity;
using Microsoft.Azure.WebJobs.Extensions.Kafka.LangEndToEndTests.Tests.Invoke.Type;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.Kafka.LangEndToEndTests.Util;
using Microsoft.Azure.WebJobs.Extensions.Kafka.LangEndToEndTests.apps.brokers;

namespace Microsoft.Azure.WebJobs.Extensions.Kafka.LangEndToEndTests.Tests
{
    public class JavaEventhubAppTest : BaseE2E, IClassFixture<KafkaE2EFixture>
    {
        private KafkaE2EFixture kafkaE2EFixture;
        ITestOutputHelper output;

        public JavaEventhubAppTest(KafkaE2EFixture kafkaE2EFixture, ITestOutputHelper output) : base(kafkaE2EFixture, Language.JAVA, BrokerType.EVENTHUB, output)
        {
            this.kafkaE2EFixture = kafkaE2EFixture;
            this.output = output;
        }

        [Fact]
        public async Task Java_App_Test_Single_Event_Eventhub()
        {
            //Generate Random Guids
            List<string> reqMsgs = Utils.GenerateRandomMsgs(AppType.SINGLE_EVENT);

            //Create HttpRequestEntity with url and query parameters
            HttpRequestEntity httpRequestEntity = Utils.GenerateTestHttpRequestEntity(Constants.JAVAAPP_EVENTHUB_PORT, Constants.JAVA_SINGLE_APP_NAME, reqMsgs);

            //Test e2e flow with trigger httpRequestEntity and expectedOutcome
            await Test(AppType.SINGLE_EVENT, InvokeType.HTTP, httpRequestEntity, null, reqMsgs);
        }


        [Fact]
        public async Task Java_App_Test_Multi_Event_Eventhub()
        {
            //Generate Random Guids
            List<string> reqMsgs = Utils.GenerateRandomMsgs(AppType.BATCH_EVENT);

            //Create HttpRequestEntity with url and query parameters
            var httpRequestEntity = Utils.GenerateTestHttpRequestEntity(Constants.JAVAAPP_EVENTHUB_PORT, Constants.JAVA_MULTI_APP_NAME, reqMsgs);

            //Test e2e flow with trigger httpRequestEntity and expectedOutcome
            await Test(AppType.BATCH_EVENT, InvokeType.HTTP, httpRequestEntity, null, reqMsgs);
        }
    }
}
