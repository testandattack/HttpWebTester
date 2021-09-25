using HttpWebTesting;
using HttpWebTesting.DataSources;
using HttpWebTesting.Enums;
using HttpWebTesting.WebTestItems;
using HttpWebTestingResults;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebTestExecutionEngine
{
    public class CommentExecution
    {
        public HttpWebTest httpWebTest { get; set; }

        public WTI_Comment comment { get; set; }

        public CommentExecution(WTI_Comment wTI_Comment, HttpWebTest webTest) 
        {
            httpWebTest = webTest;
            comment = wTI_Comment;
        }

        public WebTestResultsItem ProcessComment()
        {
            WTRI_Comment commentResults = new WTRI_Comment(comment.guid);
            return commentResults;
        }

    }
}
