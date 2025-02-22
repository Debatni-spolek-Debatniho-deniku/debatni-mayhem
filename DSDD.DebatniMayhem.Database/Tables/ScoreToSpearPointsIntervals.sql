CREATE TABLE [dbo].[ScoreToSpearPointsIntervals]
(
	[FromScore] INT NOT NULL, 
    [SpearPoints] INT NOT NULL 
)

GO

CREATE UNIQUE INDEX [IX_ScoreToSpearPointsIntervals_FromScore] ON [dbo].[ScoreToSpearPointsIntervals] ([FromScore])
