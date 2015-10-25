<Query Kind="VBExpression">
  <Connection>
    <ID>621adf80-0b16-4ed5-83e1-af6c219a19ad</ID>
    <Persist>true</Persist>
    <Driver Assembly="IQDriver" PublicKeyToken="5b59726538a49684">IQDriver.IQDriver</Driver>
    <Provider>Devart.Data.Oracle</Provider>
    <CustomCxString>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAR0fuPxMQRU6oFYtuEA5M8gAAAAACAAAAAAAQZgAAAAEAACAAAADx1Oq/FiYdXUJHb0FAR9vnsNuYUc6CfQ3DfoccBCOi4QAAAAAOgAAAAAIAACAAAABLA8moNM0lS6MzFPdQDTed/t6VkxrVTOAx6xn1NBq3I1AAAAD30m6GX2VcgBX8pPvH7r9nWh0RDSgemAJ5L1YNwFJkuFmw68yVuJ5Qw+ZXBOCJd+kGtPsAMprWdYWoAGtHnvFvv+s8rl3ZW1cVLH1rfuct1kAAAAA1XIveg/ErYJZjaIpX78CIr1rQDxDHzzv2fAb7JrCCuNNCMLyF/opRVstKCg3sNrQLoDREZfaC8Zqw1pSCNwoI</CustomCxString>
    <Server>WIN-90API3QKTDS</Server>
    <UserName>hr</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAR0fuPxMQRU6oFYtuEA5M8gAAAAACAAAAAAAQZgAAAAEAACAAAABiQ+MXlvktMSsCDkHWRP3mTd4xDDBbkR9l0RJspewg4wAAAAAOgAAAAAIAACAAAACZWqYSPGPITMXMAeTnBrQRQ9+bC0Y3BK3TESDUdjFV0BAAAADURpEBve65XMcoiVqsb3cbQAAAAKAaWlWvdLypar6vjz7iFcbjnJ6PCvjDYbLsB/ExA2iAILkITXA57scD6aN9TZsg6tLpBMybvpR0IIlw9ZmGbts=</Password>
    <EncryptCustomCxString>true</EncryptCustomCxString>
    <DriverData>
      <StripUnderscores>true</StripUnderscores>
      <QuietenAllCaps>true</QuietenAllCaps>
      <UseOciMode>false</UseOciMode>
      <IncludeRecycledTables>true</IncludeRecycledTables>
      <SID>orcl</SID>
      <ConnectAs>Default</ConnectAs>
    </DriverData>
  </Connection>
  <Output>DataGrids</Output>
</Query>

From e In Employees
Select e.FirstName,e.job.Minsalary,e.department.locationid