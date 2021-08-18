using System;
using System.Collections.Generic;
using System.Text;

namespace HttpWebTesting.Enums
{
    /// <summary>
    /// This enum describes the scope of the test executions that can occur based on the 
    /// comparison type and operands for the control.
    /// </summary>
    public enum ControlComparisonScope
    {
        /// <summary>
        /// Indicates that the control will perform either ZERO executions of the control
        /// or ONE execution of the control.
        /// </summary>
        If = 0,

        /// <summary>
        /// Indicates that the control will perform ZERO or MORE executions of the control.
        /// </summary>
        While = 1,
    };

}
