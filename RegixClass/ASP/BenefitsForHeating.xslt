<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
                 xmlns:dw1="http://egov.bg/RegiX/ASP/BenefitsForHeating/GetBenefitsForHeatingResponse"
                 xmlns:dw="http://egov.bg/RegiX/ASP/Common"
                >
  <xsl:output method="html" indent="yes"/>
  <xsl:template match="/">
    <div id="pn3">
      <h1>
        Справка за отпуснати помощи за отопление по Наредба РД-07-5
      </h1>
      <xsl:apply-templates/>
    </div>
  </xsl:template>
  <xsl:template match="dw1:GetBenefitsForHeatingResponse">
    <xsl:apply-templates/>
  </xsl:template>
  <xsl:template match="dw1:PersonData">
    <h2>Данни за лицето</h2>
    <br/>
    <span class="inf">Име: </span>
    <span class="val">
      <xsl:value-of select="dw:FirstName"/>&#160;
      <xsl:value-of select="dw:MiddleName"/>&#160;
      <xsl:value-of select="dw:LastName"/>
    </span>
    <br/>
    <span class="inf">Дата на раждане: </span>
    <span class="val">
      <xsl:value-of select="dw:BirthDatе"/>
    </span>
    <br/>
    <span class="inf">Пол: </span>
    <span class="val">
      <xsl:value-of select="dw:Gender/dw:GenderName"/>
    </span>
    <br/>
    <span class="inf">ЕГН/ЛНЧ: </span>
    <span class="val">
      <xsl:value-of select="dw:Identifier"/>
    </span>
    <br/>
  </xsl:template>
  <xsl:template match="dw1:DecisionData">
    <br/>
    <h2>Данни за заповед</h2>
    <br/>
    <span class="inf">№ на заповед: </span>
    <span class="val">
      <xsl:value-of select="dw:Details/dw:DecisionNumber"/>
    </span>
    <br/>
    <span class="inf">Дата на заповед: </span>
    <span class="val">
      <xsl:value-of select="dw:Details/dw:Date"/>
    </span>
    <br/>
    <span class="inf">Издадена от: </span>
    <span class="val">
      <xsl:value-of select="dw:Details/dw:OrganizationUnitName"/>
    </span>
    <br/>
    <span class="inf">Дата, на която спира изплащането на помощта: </span>
    <span class="val">
      <xsl:value-of select="dw:RequestEndDate"/>
    </span>
    <br/>
    <span class="inf">Изтекла ли е молбата: </span>
    <span class="val">
      <xsl:value-of select="dw:IsArchivedRequest"/>
    </span>
    <br/>
    <span class="inf">Нормативно основание: </span>
    <span class="val">
      <xsl:value-of select="dw:LegalGroundName"/>
    </span>
    <br/>
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