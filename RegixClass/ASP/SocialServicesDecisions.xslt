<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
                 xmlns:dw1="http://egov.bg/RegiX/ASP/SocialServices/GetSocialServicesDecisionsResponse"
                 xmlns:dw="http://egov.bg/RegiX/ASP/Common"
                >
  <xsl:output method="html" indent="yes"/>
  <xsl:template match="/">
    <div id="pn1">
      <h1>
        Справка за издадени заповеди за ползване на социални услуги
      </h1>
      <xsl:apply-templates/>
    </div>
  </xsl:template>
  <xsl:template match="dw1:GetSocialServicesDecisionsResponse">
    <xsl:apply-templates></xsl:apply-templates>
    <br/>
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
  <xsl:template match="dw1:SocialServicesData">
    <br/>
    <h2>Данни за заповед</h2>
    <br/>
    <xsl:apply-templates select="dw:Details"></xsl:apply-templates>
    <span class="inf">Социалната услуга: </span>
    <span class="val">
      <xsl:value-of select="dw:SocialServiceName"/>
    </span>
    <br/>
    <span class="inf">Град: </span>
    <span class="val">
      <xsl:value-of select="dw:CityName"/>
    </span>
    <br/>
    <span class="inf">Адрес: </span>
    <span class="val">
      <xsl:value-of select="dw:Address"/>
    </span>
    <br/>
    <span class="inf">Телефон: </span>
    <span class="val">
      <xsl:value-of select="dw:PhoneNumber"/>
    </span>
    <br/>
    <span class="inf">Услугата резидентен тип ли е: </span>
    <span class="val">
      <xsl:value-of select="dw:IsResidentType"/>
    </span>
    <br/>
    <span class="inf">Вид услуга: </span>
    <span class="val">
      <xsl:value-of select="dw:SocialServiceType"/>
    </span>
    <br/>
  </xsl:template>
  <xsl:template match="dw:Details">
    <span class="inf">№ на заповед: </span>
    <span class="val">
      <xsl:value-of select="dw:DecisionNumber"/>
    </span>
    <br/>
    <span class="inf">Дата на заповед: </span>
    <span class="val">
      <xsl:value-of select="dw:Date"/>
    </span>
    <br/>
    <span class="inf">Издадена от: </span>
    <span class="val">
      <xsl:value-of select="dw:OrganizationUnitName"/>
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