using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Linq;

namespace HttpWebTestingEditor
{
    public class WpfCodeEditor : TextBox
    {
        static int MAX_LEN = 10485759;  // 10 Mb - 1 byte. If length is 10MB or larger, then string was truncated.
        public bool bUrlEncodeChecked = true;
        public FormattersApplied flagFormattersApplied = FormattersApplied.None;

        public ContextMenu contextMenu { get; set; }

        public WpfCodeEditor()
        {
            contextMenu = new ContextMenu();
            BuildContextMenu();
        }

        #region -- ContextMenu -----
        private void BuildContextMenu()
        {
            var menuItem3 = AddMenuItem("cmiExpandJson", "Expand Json", "");
            menuItem3.Click += new RoutedEventHandler((s, e) => ConvertJsonString(true));
            contextMenu.Items.Add(menuItem3);

            var menuItem4 = AddMenuItem("cmiContractJson", "Contract JSON", "");
            menuItem4.Click += new RoutedEventHandler((s, e) => ConvertJsonString(false));
            contextMenu.Items.Add(menuItem4);

            var menuItem1 = AddMenuItem("cmiFormatXml", "Format XML", "");
            menuItem1.Click += new RoutedEventHandler((s, e) => FormatXml());
            contextMenu.Items.Add(menuItem1);

            var menuItem2 = AddMenuItem("cmiContractXml", "Contract XML", "");
            menuItem2.Click += new RoutedEventHandler((s, e) => ContractXml());
            contextMenu.Items.Add(menuItem2);

            var menuItem5 = AddMenuItem("cmiSplitOnAmpersand", "Split String on '&'", "");
            menuItem5.Click += new RoutedEventHandler((s, e) => SplitStringOnAmpersand());
            contextMenu.Items.Add(menuItem5);

            var menuItem6 = AddMenuItem("cmiBase64Encode", "Base64 Encode", "");
            menuItem6.Click += new RoutedEventHandler((s, e) => Base64Encode());
            contextMenu.Items.Add(menuItem6);

            var menuItem11 = AddMenuItem("cmiBase64Decode", "Base64 Decode", "");
            menuItem11.Click += new RoutedEventHandler((s, e) => Base64Decode());
            contextMenu.Items.Add(menuItem11);

            var menuItem7 = AddMenuItem("cmiUrlEncode", "Url Encode", "");
            menuItem7.Click += new RoutedEventHandler((s, e) => UrlEncode());
            contextMenu.Items.Add(menuItem7);

            var menuItem8 = AddMenuItem("cmiUrlDecode", "Url Decode", "");
            menuItem8.Click += new RoutedEventHandler((s, e) => UrlDecode());
            contextMenu.Items.Add(menuItem8);

            var menuItem9 = AddMenuItem("cmiHtmlEncode", "HTML Encode", "");
            menuItem9.Click += new RoutedEventHandler((s, e) => HtmlEncode());
            contextMenu.Items.Add(menuItem9);

            var menuItem10 = AddMenuItem("cmiHtmlDecode", "HTML Decode", "");
            menuItem10.Click += new RoutedEventHandler((s, e) => HtmlDecode());
            contextMenu.Items.Add(menuItem10);

        }

        private MenuItem AddMenuItem(string name, string header, string tooltip)
        {
            MenuItem item = new MenuItem();
            item.Name = "";
            item.Header = "Format XML";
            item.ToolTip = "";
            return item;
        }
        #endregion

        #region -- Formatters -----
        public void ConvertJsonString(bool expanded = true)
        {
            try
            {
                string startingString = RemoveQuoteEscapes(this.Text);
                startingString = RemoveLeadingAndTrailingQuotes(startingString);

                dynamic parsedJson = JsonConvert.DeserializeObject(startingString);

                if (expanded)
                {
                    this.Text = JsonConvert.SerializeObject(parsedJson, Newtonsoft.Json.Formatting.Indented);
                    SetFormattingFlag(FormattersApplied.JsonExpanded);
                }
                else
                {
                    this.Text = JsonConvert.SerializeObject(parsedJson, Newtonsoft.Json.Formatting.None);
                    RemoveFormattingFlag(FormattersApplied.JsonExpanded);
                }
            }
            catch (JsonException ex)
            {
                // Intentionally swallowing this exception because this control
                // deals with all kinds of text and it will often not have any 
                // valid json in it.
                Console.Write(ex.ToString());
            }
        }

        public void FormatXml()
        {
            try
            {
                XDocument xdoc = XDocument.Parse(this.Text);

                string xmlString = ((xdoc.Declaration == null) ? "" : xdoc.Declaration.ToString() + "\n") + xdoc.ToString(SaveOptions.None);
                this.Text = xmlString;
            }
            catch (XmlException xmlEx)
            {
                MessageBox.Show("Error attempting to reformat document as XML.\n" + xmlEx.Message + "\nMost likely cause is that the document is not an XML document", "Error Formatting  Document as XML", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Formatting  Document as XML", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ContractXml()
        {
            // Code taken from http://neilkilbride.blogspot.com/2008/04/removing-xmldocument-white-space-c.html
            // Remove inner Xml whitespace
            Regex regex = new Regex(@">\s*<");
            this.Text = regex.Replace(this.Text, "><");
        }

        public void SplitStringOnAmpersand()
        {
            SetFormattingFlag(FormattersApplied.StringSplitOnAmpersand);
            string splitter = "\r\n\r\n&";
            this.Text = this.Text.Replace("\\u0026", "&").Replace("&", splitter);
        }

        public void JoinStringOnAmpersand()
        {
            RemoveFormattingFlag(FormattersApplied.StringSplitOnAmpersand);
            this.Text = this.Text.Replace("\r\n\r\n&", "&");
        }

        public void Base64Encode()
        {
            if (this.Text.Length < MAX_LEN)
            {
                int i = 0;
                byte[] _byte = new byte[(this.Text.Length)];
                foreach (char c in this.Text.ToCharArray())
                {
                    _byte[i++] = (byte)c;
                }
                SetFormattingFlag(FormattersApplied.Base64Encoded);
                this.Text = Convert.ToBase64String(_byte);
            }
        }

        public void Base64Decode()
        {
            if (this.Text.Length < MAX_LEN)
            {
                int i = 0;
                byte[] _byte = new byte[(this.Text.Length)];
                _byte = Convert.FromBase64String(this.Text);

                StringBuilder s = new StringBuilder();
                foreach (char c in _byte)
                {
                    // Quick hack to deal with unicode. Needs to be fixed
                    if (c != 0)
                        s.Append(c);
                }
                SetFormattingFlag(FormattersApplied.Base64Decoded);
                this.Text = s.ToString();
            }
        }

        public void UrlEncode()
        {
            SetFormattingFlag(FormattersApplied.UrlEncoded);
            this.Text = HttpUtility.UrlEncode(this.Text);
        }

        public void UrlDecode()
        {

            #region ASCII Codes
            //Dec	Hex	Unicode	Char	Name
            //0	0	U+0000	NUL	Null
            //1	1	U+0001	STX	Start of Header
            //2	2	U+0002	SOT	Start of Text
            //3	3	U+0003	ETX	End of Text
            //4	4	U+0004	EOT	End of Transmission
            //5	5	U+0005	ENQ	Enquiry
            //6	6	U+0006	ACK	Acknowledge
            //7	7	U+0007	BEL	Bell
            //8	8	U+0008	BS	BackSpace
            //9	9	U+0009	HT	Horizontal Tabulation
            //10	0A	U+000A	LF	Line Feed
            //11	0B	U+000B	VT	Vertical Tabulation
            //12	0C	U+000C	FF	Form Feed
            //13	0D	U+000D	CR	Carriage Return
            //14	0E	U+000E	SO	Shift Out
            //15	0F	U+000F	SI	Shift In
            //16	10	U+0010	DLE	Data Link Escape
            //17	11	U+0011	DC1	Device Control 1 (XON)
            //18	12	U+0012	DC2	Device Control 2
            //19	13	U+0013	DC3	Device Control 3 (XOFF)
            //20	14	U+0014	DC4	Device Control 4
            //21	15	U+0015	NAK	Negative acknowledge
            //22	16	U+0016	SYN	Synchronous Idle
            //23	17	U+0017	ETB	End of Transmission Block
            //24	18	U+0018	CAN	Cancel
            //25	19	U+0019	EM	End of Medium
            //26	1A	U+001A	SUB	Substitute
            //27	1B	U+001B	ESC	Escape
            //28	1C	U+001C	FS	File Separator
            //29	1D	U+001D	GS	Group Separator
            //30	1E	U+001E	RS	Record Separator
            //31	1F	U+001F	US	Unit Separator
            //32	20	U+0020	[Space]	Space
            //33	21	U+0021	!	Exclamation mark
            //34	22	U+0022	"	Quotes
            //35	23	U+0023	#	Hash
            //36	24	U+0024	$	Dollar
            //37	25	U+0025	%	Percent
            //38	26	U+0026	&	Ampersand
            //39	27	U+0027	'	Apostrophe
            //40	28	U+0028	(	Open bracket
            //41	29	U+0029	)	Close bracket
            //42	2A	U+002A	*	Asterisk
            //43	2B	U+002B	+	Plus
            //44	2C	U+002C	,	Comma
            //45	2D	U+002D	-	Dash
            //46	2E	U+002E	.	Full stop
            //47	2F	U+002F	/	Slash
            //48	30	U+0030	0	Zero
            //49	31	U+0031	1	One
            //50	32	U+0032	2	Two
            //51	33	U+0033	3	Three
            //52	34	U+0034	4	Four
            //53	35	U+0035	5	Five
            //54	36	U+0036	6	Six
            //55	37	U+0037	7	Seven
            //56	38	U+0038	8	Eight
            //57	39	U+0039	9	Nine
            //58	3A	U+003A	:	Colon
            //59	3B	U+003B	;	Semi-colon
            //60	3C	U+003C	<	Less than
            //61	3D	U+003D	=	Equals
            //62	3E	U+003E	>	Greater than
            //63	3F	U+003F	?	Question mark
            //64	40	U+0040	@	At
            //65	41	U+0041	A	Uppercase A
            //66	42	U+0042	B	Uppercase B
            //67	43	U+0043	C	Uppercase C
            //68	44	U+0044	D	Uppercase D
            //69	45	U+0045	E	Uppercase E
            //70	46	U+0046	F	Uppercase F
            //71	47	U+0047	G	Uppercase G
            //72	48	U+0048	H	Uppercase H
            //73	49	U+0049	I	Uppercase I
            //74	4A	U+004A	J	Uppercase J
            //75	4B	U+004B	K	Uppercase K
            //76	4C	U+004C	L	Uppercase L
            //77	4D	U+004D	M	Uppercase M
            //78	4E	U+004E	N	Uppercase N
            //79	4F	U+004F	O	Uppercase O
            //80	50	U+0050	P	Uppercase P
            //81	51	U+0051	Q	Uppercase Q
            //82	52	U+0052	R	Uppercase R
            //83	53	U+0053	S	Uppercase S
            //84	54	U+0054	T	Uppercase T
            //85	55	U+0055	U	Uppercase U
            //86	56	U+0056	V	Uppercase V
            //87	57	U+0057	W	Uppercase W
            //88	58	U+0058	X	Uppercase X
            //89	59	U+0059	Y	Uppercase Y
            //90	5A	U+005A	Z	Uppercase Z
            //91	5B	U+005B	[	Open square bracket
            //92	5C	U+005C	\	Backslash
            //93	5D	U+005D	]	Close square bracket
            //94	5E	U+005E	^	Caret / hat
            //95	5F	U+005F	_	Underscore
            //96	60	U+0060	`	Grave accent
            //97	61	U+0061	a	Lowercase a
            //98	62	U+0062	b	Lowercase b
            //99	63	U+0063	c	Lowercase c
            //100	64	U+0064	d	Lowercase d
            //101	65	U+0065	e	Lowercase e
            //102	66	U+0066	f	Lowercase f
            //103	67	U+0067	g	Lowercase g
            //104	68	U+0068	h	Lowercase h
            //105	69	U+0069	i	Lowercase i
            //106	6A	U+006A	j	Lowercase j
            //107	6B	U+006B	k	Lowercase k
            //108	6C	U+006C	l	Lowercase l
            //109	6D	U+006D	m	Lowercase m
            //110	6E	U+006E	n	Lowercase n
            //111	6F	U+006F	o	Lowercase o
            //112	70	U+0070	p	Lowercase p
            //113	71	U+0071	q	Lowercase q
            //114	72	U+0072	r	Lowercase r
            //115	73	U+0073	s	Lowercase s
            //116	74	U+0074	t	Lowercase t
            //117	75	U+0075	u	Lowercase u
            //118	76	U+0076	v	Lowercase v
            //119	77	U+0077	w	Lowercase w
            //120	78	U+0078	x	Lowercase x
            //121	79	U+0079	y	Lowercase y
            //122	7A	U+007A	z	Lowercase z
            //123	7B	U+007B	{	Open brace
            //124	7C	U+007C	|	Pipe
            //125	7D	U+007D	}	Close brace
            //126	7E	U+007E	~	Tilde
            //127	7F	U+007F	DEL	Delete
            #endregion

            StringBuilder str = new StringBuilder(HttpUtility.UrlDecode(this.Text));
            str = str.Replace("%20", " ");
            str = str.Replace("%21", "!");
            str = str.Replace("%22", "\"");
            str = str.Replace("%23", "#");
            str = str.Replace("%24", "$");
            str = str.Replace("%25", "%");
            str = str.Replace("%26", "&");
            str = str.Replace("%27", "'");
            str = str.Replace("%28", "(");
            str = str.Replace("%29", ")");
            str = str.Replace("%2A", "*");
            str = str.Replace("%2B", "+");
            str = str.Replace("%2C", ",");
            str = str.Replace("%2D", "-");
            str = str.Replace("%2E", ".");
            str = str.Replace("%2F", "/");
            str = str.Replace("%30", "0");
            str = str.Replace("%31", "1");
            str = str.Replace("%32", "2");
            str = str.Replace("%33", "3");
            str = str.Replace("%34", "4");
            str = str.Replace("%35", "5");
            str = str.Replace("%36", "6");
            str = str.Replace("%37", "7");
            str = str.Replace("%38", "8");
            str = str.Replace("%39", "9");
            str = str.Replace("%3A", ":");
            str = str.Replace("%3B", ";");
            str = str.Replace("%3C", "<");
            str = str.Replace("%3D", "=");
            str = str.Replace("%3E", ">");
            str = str.Replace("%3F", "&");
            str = str.Replace("%7B", "{");
            str = str.Replace("%7D", "}");

            SetFormattingFlag(FormattersApplied.UrlDecoded);
            this.Text = str.ToString();
        }

        public void HtmlEncode()
        {
            SetFormattingFlag(FormattersApplied.HtmlEncoded);
            this.Text = System.Web.HttpUtility.HtmlEncode(this.Text);
        }

        public void HtmlDecode()
        {
            StringWriter myWriter = new StringWriter();
            StringWriter myWriter2 = new StringWriter();

            // Decode the encoded string.
            HttpUtility.HtmlDecode(this.Text, myWriter);
            HttpUtility.HtmlDecode(myWriter.ToString(), myWriter2);
            SetFormattingFlag(FormattersApplied.HtmlDecoded);
            this.Text = myWriter2.ToString();
        }
        #endregion

        #region -- Utility Methods --------------
        private string AddQuoteEscapes(string originalString)
        {
            if (flagFormattersApplied.HasFlag(FormattersApplied.QuoteEscapesRemoved))
            {
                RemoveFormattingFlag(FormattersApplied.QuoteEscapesRemoved);
                return originalString.Replace("\"", "\\\"");
            }
            else
                return originalString;
        }

        private string RemoveQuoteEscapes(string originalString)
        {
            if (originalString.Contains("\\\""))
            {
                string newString = originalString.Replace("\\\"", "\"");
                SetFormattingFlag(FormattersApplied.QuoteEscapesRemoved);
                return newString;
            }

            RemoveFormattingFlag(FormattersApplied.QuoteEscapesRemoved);
            return originalString;
        }

        private string AddLeadingAndTrailingQuotes(string originalString)
        {
            string strStart = (flagFormattersApplied.HasFlag(FormattersApplied.LeadingQuoteRemoved) ? "\"" : "");
            string strEnd = (flagFormattersApplied.HasFlag(FormattersApplied.TrailingQuoteRemoved) ? "\"" : "");

            RemoveFormattingFlag(FormattersApplied.LeadingQuoteRemoved);
            RemoveFormattingFlag(FormattersApplied.TrailingQuoteRemoved);

            return strStart + originalString + strEnd;
        }

        private string RemoveLeadingAndTrailingQuotes(string originalString)
        {
            int x = 0;
            int y = 0;

            // Determine leading quote
            if (originalString.StartsWith("\""))
            {
                SetFormattingFlag(FormattersApplied.LeadingQuoteRemoved);
                x = 1;
            }
            else
                RemoveFormattingFlag(FormattersApplied.LeadingQuoteRemoved);

            // Determine trailing quote
            if (originalString.EndsWith("\""))
            {
                y = (originalString.Length - 1) - x;
                SetFormattingFlag(FormattersApplied.TrailingQuoteRemoved);
            }
            else
                RemoveFormattingFlag(FormattersApplied.TrailingQuoteRemoved);

            // Send appropriate string back
            if (x != 0 || y != 0)
                return originalString.Substring(x, y);
            else
                return originalString;
        }
        #endregion

        #region -- Flag Methods -----------------------
        private void SetFormattingFlag(FormattersApplied FlagToSet)
        {
            flagFormattersApplied = flagFormattersApplied | FlagToSet;
        }

        private void RemoveFormattingFlag(FormattersApplied FlagToSet)
        {
            flagFormattersApplied = flagFormattersApplied & ~FlagToSet;
        }

        private void ClearAllFormattingFlags()
        {
            flagFormattersApplied = 0;
        }
        #endregion
    }

    [Flags]
    public enum FormattersApplied
    {
        None = 0,
        JsonExpanded = 1,
        XmlFormatted = 2,
        Base64Decoded = 4,
        UrlDecoded = 8,
        HtmlDecoded = 16,
        StringSplitOnAmpersand = 32,
        LeadingQuoteRemoved = 64,
        TrailingQuoteRemoved = 128,
        QuoteEscapesRemoved = 256,
        Base64Encoded = 512,
        UrlEncoded = 1024,
        HtmlEncoded = 2048,
        Binary_DEBUG_Decoded = 4096
    }
}
