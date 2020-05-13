<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"  
                  xmlns:dw1="http://egov.bg/RegiX/GRAO/BR/MaritalStatusResponse"
                xmlns="http://egov.bg/RegiX/GRAO/BR/MaritalStatusResponse">
  <xsl:output method="html" indent="yes"/>
  <xsl:template match="/">
  <div id="pn7">
    <h1>
      Справка за семейно положение
    </h1>
    <xsl:apply-templates select="dw1:MaritalStatusResponse"/>
  </div>
  </xsl:template>
  <xsl:template match="dw1:MaritalStatusResponse">

    <xsl:variable name="nm" select="dw1:FirstName" ></xsl:variable>
    <xsl:if test="string-length($nm) > 0">
      <span class="inf">Име: </span>
      <span class="val">
        <xsl:value-of select="dw1:FirstName"/>&#160;<xsl:value-of select="dw1:MiddleName"/>&#160;<xsl:value-of select="dw1:LastName"/>
      </span>
      <br/>
    </xsl:if>

    <!--<span class="inf">Име: </span>
    <xsl:value-of select="dw1:FirstName"/>&#160;<xsl:value-of select="dw1:MiddleName"/>&#160;<xsl:value-of select="dw1:LastName"/>
    <br/>-->
    <xsl:apply-templates></xsl:apply-templates>
    <span class="inf">Статус: </span>
    <span class="val">
      <xsl:value-of select="dw1:MaritalStatusName"/>
    </span>
    <br/>
  </xsl:template>
  <xsl:template match="dw1:Title">
      <h1><xsl:value-of select="." /></h1>
  </xsl:template>
  <xsl:template match="dw1:ReportDate">
      <span class="inf">Към дата: </span>
      <span class="val">
        <xsl:value-of select="." />
      </span>
      <br/>
  </xsl:template>
  <xsl:template match="dw1:EGN">
    <span class="inf">ЕГН/ЛНЧ: </span>
    <span class="val">
      <xsl:value-of select="." />
    </span>
    <br/>
  </xsl:template>
  <!--<xsl:template match="dw1:FirstName">
      <span class="inf">Име: </span>
      <span class="val">
        <xsl:value-of select="dw1:FirstName"/>&#160;<xsl:value-of select="dw1:MiddleName"/>&#160;<xsl:value-of select="dw1:LastName"/>
      </span>
      <br/>
  </xsl:template>-->
  <!--<xsl:template match="dw1:Status">
    <span class="inf">Статус: </span>
    <span class="val">
      <xsl:value-of select="dw1:MaritalStatusCode"/>&#160;<xsl:value-of select="dw1:MaritalStatusName"/>
    </span>
    <br/>
  </xsl:template>-->
  <xsl:template match="Error">
    <span class="err inf">Грешка от Regix: </span>
    <span class="err val">
      <xsl:value-of select="." />
    </span>
  </xsl:template>
  <xsl:template match="*">
  </xsl:template>
</xsl:stylesheet>