Option Strict Off
Imports System
Imports System.Collections.Generic
Imports NXOpen
Imports NXOpen.UF

Module NXjournal

    Public ufs As UFSession = UFSession.GetUFSession()
    Public Modl As UFModl

Sub Main (ByVal args() As String) 

Dim theSession As NXOpen.Session = NXOpen.Session.GetSession()
Dim workPart As NXOpen.Part = theSession.Parts.Work

Dim displayPart As NXOpen.Part = theSession.Parts.Display

' ----------------------------------------------
'   Menu: Insert->Design Feature->Block...
' ----------------------------------------------
Dim markId1 As NXOpen.Session.UndoMarkId = Nothing
markId1 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Start")

Dim nullNXOpen_Features_Feature As NXOpen.Features.Feature = Nothing

Dim blockFeatureBuilder1 As NXOpen.Features.BlockFeatureBuilder = Nothing
blockFeatureBuilder1 = workPart.Features.CreateBlockFeatureBuilder(nullNXOpen_Features_Feature)

blockFeatureBuilder1.BooleanOption.Type = NXOpen.GeometricUtilities.BooleanOperation.BooleanType.Create

Dim targetBodies1(0) As NXOpen.Body
Dim nullNXOpen_Body As NXOpen.Body = Nothing

targetBodies1(0) = nullNXOpen_Body
blockFeatureBuilder1.BooleanOption.SetTargetBodies(targetBodies1)

blockFeatureBuilder1.BooleanOption.Type = NXOpen.GeometricUtilities.BooleanOperation.BooleanType.Create

Dim targetBodies2(0) As NXOpen.Body
targetBodies2(0) = nullNXOpen_Body
blockFeatureBuilder1.BooleanOption.SetTargetBodies(targetBodies2)

theSession.SetUndoMarkName(markId1, "Block Dialog")

Dim coordinates1 As NXOpen.Point3d = New NXOpen.Point3d(0.0, 0.0, 0.0)
Dim point1 As NXOpen.Point = Nothing
point1 = workPart.Points.CreatePoint(coordinates1)

blockFeatureBuilder1.OriginPoint = point1

Dim unit1 As NXOpen.Unit = CType(workPart.UnitCollection.FindObject("Inch"), NXOpen.Unit)

Dim expression1 As NXOpen.Expression = Nothing
expression1 = workPart.Expressions.CreateSystemExpressionWithUnits("0", unit1)

Dim markId2 As NXOpen.Session.UndoMarkId = Nothing
markId2 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Block")

theSession.DeleteUndoMark(markId2, Nothing)

Dim markId3 As NXOpen.Session.UndoMarkId = Nothing
markId3 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Block")

blockFeatureBuilder1.Type = NXOpen.Features.BlockFeatureBuilder.Types.OriginAndEdgeLengths

blockFeatureBuilder1.OriginPoint = point1

Dim originPoint1 As NXOpen.Point3d = New NXOpen.Point3d(0.0, 0.0, 0.0)
blockFeatureBuilder1.SetOriginAndLengths(originPoint1, "10", "10", "10")

blockFeatureBuilder1.SetBooleanOperationAndTarget(NXOpen.Features.Feature.BooleanType.Create, nullNXOpen_Body)

Dim feature1 As NXOpen.Features.Feature = Nothing
feature1 = blockFeatureBuilder1.CommitFeature()

theSession.DeleteUndoMark(markId3, Nothing)

theSession.SetUndoMarkName(markId1, "BLOCK")

blockFeatureBuilder1.Destroy()

workPart.MeasureManager.SetPartTransientModification()

workPart.Expressions.Delete(expression1)

workPart.MeasureManager.ClearPartTransientModification()

' ----------------------------------------------
'   Menu: Tools->Journal->Stop Recording
' ----------------------------------------------


        Dim theFaces() As Face = Nothing
        theFaces = SelectFaces("select some faces")
        Dim faceType As Integer
        Dim facePt(2) As Double
        Dim faceDir(2) As Double
        Dim bbox(5) As Double
        Dim faceRadius As Double
        Dim faceRadData As Double
        Dim normDirection As Integer

        If IsNothing(theFaces) Then
            Return
        End If

        For Each item As Face In theFaces
            ufs.Modl.AskFaceData(item.Tag, faceType, facePt, faceDir, bbox, faceRadius, faceRadData, normDirection)




Dim markId4 As NXOpen.Session.UndoMarkId = Nothing
markId4 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Start")

Dim cylinderBuilder1 As NXOpen.Features.CylinderBuilder = Nothing
cylinderBuilder1 = workPart.Features.CreateCylinderBuilder(nullNXOpen_Features_Feature)

cylinderBuilder1.BooleanOption.Type = NXOpen.GeometricUtilities.BooleanOperation.BooleanType.Create

Dim targetBodies3(0) As NXOpen.Body
targetBodies3(0) = nullNXOpen_Body
cylinderBuilder1.BooleanOption.SetTargetBodies(targetBodies3)

cylinderBuilder1.Diameter.SetFormula("4")

cylinderBuilder1.Height.SetFormula("10")

cylinderBuilder1.BooleanOption.Type = NXOpen.GeometricUtilities.BooleanOperation.BooleanType.Subtract

Dim targetBodies4(0) As NXOpen.Body
Dim body1 As NXOpen.Body = CType(workPart.Bodies.FindObject("BLOCK(16)"), NXOpen.Body)

targetBodies4(0) = body1
cylinderBuilder1.BooleanOption.SetTargetBodies(targetBodies4)

theSession.SetUndoMarkName(markId4, "Cylinder Dialog")

Dim expression2 As NXOpen.Expression = Nothing
expression2 = workPart.Expressions.CreateSystemExpressionWithUnits("0", unit1)

Dim origin1 As NXOpen.Point3d = New NXOpen.Point3d(facePt(0), facePt(1), facePt(2))
Dim vector1 As NXOpen.Vector3d = New NXOpen.Vector3d(0.0, 0.0, 1.0)
Dim direction1 As NXOpen.Direction = Nothing
direction1 = workPart.Directions.CreateDirection(origin1, vector1, NXOpen.SmartObject.UpdateOption.WithinModeling)

Dim axis1 As NXOpen.Axis = Nothing
axis1 = cylinderBuilder1.Axis

axis1.Direction = direction1

Dim expression3 As NXOpen.Expression = Nothing
expression3 = workPart.Expressions.CreateSystemExpressionWithUnits("0", unit1)

Dim markId5 As NXOpen.Session.UndoMarkId = Nothing
markId5 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Cylinder")

theSession.DeleteUndoMark(markId5, Nothing)

Dim markId6 As NXOpen.Session.UndoMarkId = Nothing
markId6 = theSession.SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Cylinder")

Dim nXObject1 As NXOpen.NXObject = Nothing
nXObject1 = cylinderBuilder1.Commit()

theSession.DeleteUndoMark(markId6, Nothing)

theSession.SetUndoMarkName(markId4, "Cylinder")

Dim expression4 As NXOpen.Expression = cylinderBuilder1.Height

Dim expression5 As NXOpen.Expression = cylinderBuilder1.Diameter

cylinderBuilder1.Destroy()

workPart.MeasureManager.SetPartTransientModification()

workPart.Expressions.Delete(expression3)

workPart.MeasureManager.ClearPartTransientModification()

workPart.MeasureManager.SetPartTransientModification()

workPart.Expressions.Delete(expression2)

workPart.MeasureManager.ClearPartTransientModification()

' ----------------------------------------------
'   Menu: Tools->Journal->Stop Recording
' ----------------------------------------------
Next

For Each item As Face In theFaces
            ufs.Modl.AskFaceData(item.Tag, faceType, facePt, faceDir, bbox, faceRadius, faceRadData, normDirection)

            

Next


    End Sub

    Public Function SelectFaces(ByVal propt As String) As Face()

        Dim theUI As UI = UI.GetUI
        Dim title As String = "Select faces"
        Dim includeFeatures As Boolean = False
        Dim keepHighlighted As Boolean = False
        Dim selAction As Selection.SelectionAction = Selection.SelectionAction.ClearAndEnableSpecific
        Dim scope As Selection.SelectionScope = Selection.SelectionScope.AnyInAssembly
        Dim selectionMask(0) As Selection.MaskTriple
        Dim selectedObjects() As TaggedObject = Nothing
        Dim selectedFaces As New List(Of Face)

        With selectionMask(0)
            .Type = UFConstants.UF_solid_type
            .Subtype = 0
            .SolidBodySubtype = UFConstants.UF_UI_SEL_FEATURE_ANY_FACE
        End With

        Dim responce1 As Selection.Response = theUI.SelectionManager.SelectTaggedObjects(
            propt, title, scope, selAction, includeFeatures, keepHighlighted, selectionMask, selectedObjects)

        If responce1 = Selection.Response.Ok Then
            For Each item As TaggedObject In selectedObjects
                selectedFaces.Add(item)
            Next
            Return selectedFaces.ToArray
        Else
            Return Nothing
        End If

    End Function

End Module


