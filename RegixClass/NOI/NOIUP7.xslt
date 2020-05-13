<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"  
                 xmlns:dw="http://egov.bg/RegiX/NOI/RP"
                xmlns:dw1="http://egov.bg/RegiX/NOI/RP/UP7Response"
                xmlns="http://egov.bg/RegiX/NOI/RP/UP7Response">
  <xsl:output method="html" indent="yes"/>
  <xsl:template match="/">
  <div id="pn5">
    <xsl:variable name="ttl">
      <xsl:value-of select="dw1:UP7Response/dw1:Title" />
    </xsl:variable>
    <xsl:if test="string-length($ttl) = 0">
      <h1>Справка за размер и вид на пенсия и добавка (УП-7)</h1>
      <span class="val">Няма данни!</span>
    </xsl:if>
    <xsl:apply-templates select="dw1:UP7Response"/>
  </div>
  </xsl:template>
  <xsl:template match="dw1:UP7Response">
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
    <xsl:variable name="nm" select="dw:Name" ></xsl:variable>
    <xsl:if test="string-length($nm) > 0">
      <span class="inf">Име: </span>
      <span class="val">
        <xsl:value-of select="dw:Name"/>&#160;<xsl:value-of select="dw:Surname"/>&#160;<xsl:value-of select="dw:FamilyName"/>
      </span>
      <br/>
    </xsl:if>
  </xsl:template>
  <xsl:template match="dw1:PensionerStatus">
    <span class="inf">Статус: </span>
    <span class="val">
      <xsl:value-of select="." />
    </span>
    <br/>
  </xsl:template>
  <xsl:template match="dw1:ReceivingAmountNumbers">
    <span class="inf">Размер на сумата за получаване за текущия месец: </span>
    <span class="val">
      <xsl:value-of select="." />
    </span>
    <br/>
  </xsl:template>
  <xsl:template match="dw1:DateOfDeath">
    <span class="inf">Дата на смърт: </span>
    <span class="val">
      <!--<xsl:value-of select="format-date(.,'[Y0001][M01][D01]')" />-->
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
  <xsl:template match="dw1:Pensions">
    <xsl:if test="count(dw:Pension) > 0">
    <span class="inf">Пенсии: </span>
   
      <ul>
        <xsl:for-each select="dw:Pension">
          <li>
            <span class="inf">
              <xsl:value-of select="dw:PensionType" />
            </span>
            <span class="val">
              <xsl:value-of select="dw:PensionAmount " />
            </span>
          </li>
        </xsl:for-each>
      </ul>
    </xsl:if>
  </xsl:template>
  <xsl:template match="dw1:AdditionAndReductionAmounts ">
    <xsl:if test="count(dw:AdditionAndReductionAmount) > 0">
      <span class="inf">Добавки и удръжки: </span>
      <ul>
        <xsl:for-each select="dw:AdditionAndReductionAmount">
          <li>
            <span class="inf">
              <xsl:value-of select="dw:TypeName" />
            </span>
            <span class="val">
              <xsl:value-of select="dw:Value " />
            </span>
          </li>
        </xsl:for-each>
      </ul>
    </xsl:if>
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