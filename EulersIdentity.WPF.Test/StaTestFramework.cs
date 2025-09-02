using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;
using System.Windows;

namespace Sde.EulersIdentity.WPF.Test
{
    /// <summary>
    /// A custom test framework to ensure tests run in a Single Threaded Apartment (STA).
    /// </summary>
    public class StaTestFramework : XunitTestFramework
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StaTestFramework"/> class.
        /// </summary>
        /// <param name="messageSink">The message sink to report results.</param>
        public StaTestFramework(IMessageSink messageSink)
            : base(messageSink)
        {
        }
    }

    /// <summary>
    /// A custom test case to ensure tests run in STA.
    /// </summary>
    public class StaTestCase : XunitTestCase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StaTestCase"/> class.
        /// </summary>
        public StaTestCase(IMessageSink diagnosticMessageSink, TestMethodDisplay defaultMethodDisplay, TestMethodDisplayOptions defaultMethodDisplayOptions, ITestMethod testMethod, object[] testMethodArguments = null)
            : base(diagnosticMessageSink, defaultMethodDisplay, defaultMethodDisplayOptions, testMethod, testMethodArguments)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StaTestCase"/> class.
        /// Required for serialization.
        /// </summary>
        public StaTestCase()
        {
        }

        /// <inheritdoc />
        public override async Task<RunSummary> RunAsync(IMessageSink diagnosticMessageSink, IMessageBus messageBus, object[] constructorArguments, ExceptionAggregator aggregator, CancellationTokenSource cancellationTokenSource)
        {
            var runSummary = new RunSummary();

            var staThread = new Thread(() =>
            {
                try
                {
                    // Ensure the WPF Application object is initialized on the STA thread.
                    if (Application.Current == null)
                    {
                        new Application();
                    }

                    // Use a Dispatcher to ensure all UI-related operations are executed on the STA thread.
                    var dispatcher = System.Windows.Threading.Dispatcher.CurrentDispatcher;
                    dispatcher.Invoke(() =>
                    {
                        var task = base.RunAsync(diagnosticMessageSink, messageBus, constructorArguments, aggregator, cancellationTokenSource);
                        task.Wait();
                        runSummary = task.Result;
                    });
                }
                catch (Exception ex)
                {
                    aggregator.Add(ex);
                }
            });

            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
            staThread.Join();

            return runSummary;
        }

        /// <inheritdoc />
        public override void Serialize(IXunitSerializationInfo data)
        {
            base.Serialize(data);
        }

        /// <inheritdoc />
        public override void Deserialize(IXunitSerializationInfo data)
        {
            base.Deserialize(data);
        }
    }

    /// <summary>
    /// Discoverer for the <see cref="StaFactAttribute"/>.
    /// </summary>
    public class StaFactDiscoverer : IXunitTestCaseDiscoverer
    {
        private readonly IMessageSink diagnosticMessageSink;

        /// <summary>
        /// Initializes a new instance of the <see cref="StaFactDiscoverer"/> class.
        /// </summary>
        /// <param name="diagnosticMessageSink">The message sink to report diagnostics.</param>
        public StaFactDiscoverer(IMessageSink diagnosticMessageSink)
        {
            this.diagnosticMessageSink = diagnosticMessageSink;
        }

        /// <inheritdoc />
        public IEnumerable<IXunitTestCase> Discover(ITestFrameworkDiscoveryOptions discoveryOptions, ITestMethod testMethod, IAttributeInfo factAttribute)
        {
            yield return new StaTestCase(this.diagnosticMessageSink, discoveryOptions.MethodDisplayOrDefault(), discoveryOptions.MethodDisplayOptionsOrDefault(), testMethod);
        }
    }

    /// <summary>
    /// Attribute to ensure a test method runs in STA.
    /// </summary>
    [XunitTestCaseDiscoverer("Sde.EulersIdentity.WPF.Test.StaFactDiscoverer", "EulersIdentity.WPF.Test")]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class StaFactAttribute : FactAttribute
    {
    }
}