<?xml version="1.0" encoding="utf-8"?><xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform"><xsl:template match="/">
  <html>
  <body>
    <h2>THỐNG KÊ THEO THỜI GIAN.</h2>
	<h3>
       <xsl:value-of select="TimeSheet/DateRange"/>
    </h3>
    <table border="1">
    <tr bgcolor="#9acd32">
      <th align="left">Ngày</th>
      <th align="left">Thao tác</th>
	  <th align="left">Ghi chú</th>
	  <th align="left">Thời gian</th>
    </tr>
    <xsl:for-each select="TimeSheet/TimeRow">
    <tr>
      <td><xsl:value-of select="Date"/></td>
      <td><xsl:value-of select="Code"/></td>
	  <td><xsl:value-of select="Ticket"/></td>
	  <td><xsl:value-of select="Duration"/></td>
    </tr>
    </xsl:for-each>
    </table>
  </body>
  </html>
</xsl:template></xsl:stylesheet>