namespace HttpWebTesting.Enums
{
    public enum WebTestOutcome
    {
        /// <summary>
        /// The web test execution completed without any errors.
        /// </summary>
        Passed = 1,

        /// <summary>
        /// The web test execution completed, but had  errors.
        /// </summary>
        /// <remarks>
        /// This will occur when the <see cref="HttpWebTest.StopOnError"/> flag
        /// is set to false and one or more requests fail.
        /// </remarks>
        Failed = 2,

        /// <summary>
        /// The web test execution was stopped prior to the 
        /// end of the test due to encountering an error.
        /// </summary>
        /// <remarks>
        /// This will occur when the <see cref="HttpWebTest.StopOnError"/> flag
        /// is set to true and one request fails.
        /// </remarks>
        StoppedOnError = 3,
        
        /// <summary>
        /// The web test execution was stopped due to an issue with the
        /// test engine (most likely due to an unhandled exception being 
        /// thrown in custom code.
        /// </summary>
        Aborted = 4
    }
}
