<Query Kind="VBProgram" />

Sub Main
	    Try
            Dim input As New OleDbParameter
            Dim ds As New DataSet
            Using Connection As New OleDbConnection(connectionString)
                'input.Value = ComboBox1.Text 'need to convert?
                input.Value = rDate
                Command = New OleDbCommand
                With Command
                    .CommandText = "qNIM" 'Access query name
                    .CommandType = CommandType.StoredProcedure
                    .Connection = Connection
                    Command.Parameters.Add(input)
                End With

                Connection.Open()
                Dim reader As OleDbDataReader = Command.ExecuteReader(CommandBehavior.CloseConnection)
                If reader.HasRows Then
                    ds = New DataSet
                    ds.Load(reader, LoadOption.PreserveChanges, "myTable")


                    'While reader.Read()
                    '    Console.WriteLine(reader.GetString(0))
                    'End While
                    Dim pRow As DataRow
                    Dim nim As NIM
                    _NimOut = New List(Of NIM)
                    For Each pRow In ds.Tables("myTable").Rows

                        nim = New NIM With {.dDate = pRow("Reporting_Date").ToString(), .con_Geogrphay = pRow("Country").ToString(), _
                                              .dScenario = pRow("Scenario").ToString(), .mValue = pRow("NIM_Value").ToString()}
                        _NimOut.Add(nim)


                    Next
                    RecordsFound = True
                End If
                reader.Close()
            End Using


        Catch ex As Exception
            MsgBox(ex.ToString)
            RecordsFound = False
            '  ThisAddIn.taskPaneControl1.Invoke(New DisplayStatusDelegateTP(AddressOf ThisAddIn.taskPaneControl1.DisplayStatusStrip2), "Error on Database Action")
            RaiseEvent DB_ExportEvent(Me, New DBEventsArgs("Error DB action-GetNIM_PivotData"))
        Finally
        End Try
End Sub

' Define other methods and classes here
