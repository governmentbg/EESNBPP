<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"  
                 xmlns:dw="http://egov.bg/RegiX/NOI/RP"
                xmlns:dw1="http://egov.bg/RegiX/NOI/RP/UP8Response"
                xmlns="http://egov.bg/RegiX/NOI/RP/UP8Response">
  <xsl:output method="html" indent="yes"/>
  <xsl:template match="/">
  <div id="pn6">
    <xsl:variable name="ttl">
      <xsl:value-of select="dw1:UP8Response/dw1:Title" />
    </xsl:variable>
    <xsl:if test="string-length($ttl) = 0">
      <h1>
        Справка за доход от пенсия и добавка (УП-8)
      </h1>
      <span class="val">Няма данни!</span>
    </xsl:if>
    <xsl:apply-templates select="dw1:UP8Response"/>
  </div>
  </xsl:template>
  <xsl:template match="dw1:UP8Response">
    <xsl:apply-templates></xsl:apply-templates>
  </xsl:template>
  <xsl:template match="dw1:Title">
      <h1><xsl:value-of select="." /></h1>
  </xsl:template>
  <xsl:template match="dw1:ForDate">
      <span class="inf">Към дата: </span>
      <span class="val">
        <xsl:value-of select="." />
      </span>
      <br/>
  </xsl:template>
  <xsl:template match="dw1:TerritorialDivisionNOI">
    <span class="inf">Поделение на НОИ: </span>
    <span class="val">
      <xsl:value-of select="." />
    </span>
    <br/>
  </xsl:template>
  <xsl:template match="dw1:Identifier">
    <span class="inf">ЕГН/ЛНЧ: </span>
    <span class="val">
      <xsl:value-of select="." />
    </span>
    <br/>
  </xsl:template>
  <xsl:template match="dw1:Names">
    <xsl:variable name="nm" select="dw:Name" />
    <xsl:if test="string-length($nm) > 0">
      <span class="inf">Име: </span>
      <span class="val">
        <xsl:value-of select="dw:Name"/>&#160;<xsl:value-of select="dw:Surname"/>&#160;<xsl:value-of select="dw:FamilyName"/>
      </span>
      <br/>
    </xsl:if>
  </xsl:template>
  <xsl:template match="dw1:Status">
    <span class="inf">Статус: </span>
    <span class="val">
      <xsl:value-of select="." />
    </span>
    <br/>
  </xsl:template>
  <xsl:template match="dw1:DateOfDeath">
    <span class="inf">Дата на смърт : </span>
    <span class="val">
      <xsl:value-of select="." />
    </span>
    <br/>
  </xsl:template>
  <xsl:template match="dw1:ContentText">
    <span class="inf">
      <xsl:value-of select="." />
    </span>
    <br/>
  </xsl:template>
  <xsl:template match="dw1:PensionPayments">
    <table style="border: 1px solid black;">
      <tr>
        <th>
          <span class="inf">Месец</span>
        </th>
        <th>
          <span class="inf">Получена сума (общо)</span>
        </th>
        <th>
          <span class="inf">Пенсии (общо всички получавани пенсии)</span>
        </th>
        <th>
          <span class="inf">Добавка за чужда помощ</span>
        </th>
        <th>
          <span class="inf">Други добавки</span>
        </th>
      </tr>
      <xsl:for-each select="dw:PensionPayment">
        <tr>
          <td>
            <span class="val" style="text-algin: left;">
              <xsl:value-of select="dw:Month" />
            </span>
          </td>
          <td style="text-algin: right;">
            <span class="val" >
              <xsl:value-of select="dw:TotalAmount" />
            </span>
          </td>
          <td>
            <span class="val" style="text-algin: right;">
              <xsl:value-of select="dw:PensionAmount" />
            </span>
          </td>
          <td>
            <span class="val">
              <xsl:value-of select="dw:AdditionForAssistance" />
            </span>
          </td>
          <td>
            <span class="val">
              <xsl:value-of select="dw:OtherAddition" />
            </span>
          </td>
        </tr>
      </xsl:for-each>
    </table>
  </xsl:template>
  <xsl:template match="Error">
    <span class="err inf">Грешка от Regix: </span>
    <span class="err val">
      <xsl:value-of select="." />
    </span>
  </xsl:template>
  <xsl:template match="*">
  </xsl:template>
</xsl:stylesheet>