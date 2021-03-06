﻿<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"  
                 xmlns:dw="http://egov.bg/RegiX/NOI/RP"
                xmlns:dw1="http://egov.bg/RegiX/NOI/RP/PensionRightResponse"
                xmlns="http://egov.bg/RegiX/NOI/RP/PensionRightResponse">
  <xsl:output method="html" indent="yes"/>
  <xsl:template match="/">
  <div id="pn4">
    <xsl:variable name="ttl">
      <xsl:value-of select="dw1:PensionRightResponse/dw1:Title" />
    </xsl:variable>
    <xsl:if test="string-length($ttl) = 0">
      <h1>Справка за наличието на упражнено право на пенсия за осигурителен стаж и възраст</h1>
      <span class="val">Няма данни!</span>
    </xsl:if>
    <xsl:apply-templates select="dw1:PensionRightResponse"/>
  </div>
  </xsl:template>
  <xsl:template match="dw1:PensionRightResponse">
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
  <xsl:template match="dw1:Status">
    <span class="inf">Статус: </span>
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
  <xsl:template match="dw1:PensionCharacteristics">
    <ul>
      <xsl:for-each select="dw:PensionCharacteristic">
        <li>
          <span class="inf">
            <xsl:value-of select="dw:DataText" />
          </span>
          <span class="val">
            <xsl:value-of select="dw:ValueText" />
          </span>
        </li>
      </xsl:for-each>
    </ul>
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