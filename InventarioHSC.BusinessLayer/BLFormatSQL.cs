namespace InventarioHSC.BusinessLayer
{
    public class BLFormatSQL
    {
        #region HTML

        public string FormatTSqlToHTML(string inputString)
        {
            return FormatTSqlWithOptionsToHTML(
            inputString,
            true,
            "\t",
            4,
            999,
            1,
            1,
            true,
            false,
            false,
            true,
            true,
            true,
            false,
            true,
            true,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            false,
            true
            );
        }

        private string FormatTSqlWithOptionsToHTML(
        string inputString,
        bool reFormat,
        string indent,
        int spacesPerTab,
        int maxLineWidth,
        int statementBreaks,
        int clauseBreaks,
        bool expandCommaLists,
        bool trailingCommas,
        bool spaceAfterExpandedComma,
        bool expandBooleanExpressions,
        bool expandCaseStatements,
        bool expandBetweenConditions,
        bool breakJoinOnSections,
        bool uppercaseKeywords,
        bool coloring,
        bool keywordStandardization,
        bool useParseErrorPlaceholder,
        bool obfuscate,
        bool randomizeColor,
        bool randomizeLineLengths,
        bool randomizeKeywordCase,
        bool preserveComments,
        bool enableKeywordSubstitution,
        bool expandInLists
        )
        {
            PoorMansTSqlFormatterLib.Interfaces.ISqlTreeFormatter formatter = null;
            if (reFormat)
            {
                formatter = new PoorMansTSqlFormatterLib.Formatters.TSqlStandardFormatter(new PoorMansTSqlFormatterLib.Formatters.TSqlStandardFormatterOptions
                {
                    IndentString = indent,
                    SpacesPerTab = spacesPerTab,
                    MaxLineWidth = maxLineWidth,
                    NewStatementLineBreaks = statementBreaks,
                    NewClauseLineBreaks = clauseBreaks,
                    ExpandCommaLists = expandCommaLists,
                    TrailingCommas = trailingCommas,
                    SpaceAfterExpandedComma = spaceAfterExpandedComma,
                    ExpandBooleanExpressions = expandBooleanExpressions,
                    ExpandCaseStatements = expandCaseStatements,
                    ExpandBetweenConditions = expandBetweenConditions,
                    BreakJoinOnSections = breakJoinOnSections,
                    UppercaseKeywords = uppercaseKeywords,
                    HTMLColoring = coloring,
                    KeywordStandardization = keywordStandardization,
                    ExpandInLists = expandInLists
                });
            }
            else if (obfuscate)
                formatter = new PoorMansTSqlFormatterLib.Formatters.TSqlObfuscatingFormatter(
                randomizeKeywordCase,
                randomizeColor,
                randomizeLineLengths,
                preserveComments,
                enableKeywordSubstitution
                );
            else
                formatter = new PoorMansTSqlFormatterLib.Formatters.TSqlIdentityFormatter(coloring);
            if (useParseErrorPlaceholder)
                formatter.ErrorOutputPrefix = "{PARSEERRORPLACEHOLDER}";
            return FormatTSqlWithFormatter(inputString, formatter);
        }

        private string FormatTSqlWithFormatter(string inputString, PoorMansTSqlFormatterLib.Interfaces.ISqlTreeFormatter formatter)
        {
            PoorMansTSqlFormatterLib.SqlFormattingManager fullFormatter = new PoorMansTSqlFormatterLib.SqlFormattingManager(new PoorMansTSqlFormatterLib.Formatters.HtmlPageWrapper(formatter));
            return fullFormatter.Format(inputString);
        }

        #endregion HTML

        #region SimpleText

        public string FormatTSqlToString(string inputString)
        {
            var options = new PoorMansTSqlFormatterLib.Formatters.TSqlStandardFormatterOptions
            {
                KeywordStandardization = true,
                IndentString = "\t",
                SpacesPerTab = 4,
                MaxLineWidth = 999,
                NewStatementLineBreaks = 1,
                NewClauseLineBreaks = 1,
                TrailingCommas = false,
                SpaceAfterExpandedComma = false,
                ExpandBetweenConditions = true,
                ExpandBooleanExpressions = true,
                ExpandCaseStatements = true,
                ExpandCommaLists = true,
                BreakJoinOnSections = false,
                UppercaseKeywords = true,
                ExpandInLists = true
            };

            PoorMansTSqlFormatterLib.Interfaces.ISqlTreeFormatter _formatter = new PoorMansTSqlFormatterLib.Formatters.TSqlStandardFormatter(options);
            var formattingManager = new PoorMansTSqlFormatterLib.SqlFormattingManager(_formatter);
            bool parsingError = false;

            return formattingManager.Format(inputString, ref parsingError);
        }

        #endregion SimpleText
    }
}