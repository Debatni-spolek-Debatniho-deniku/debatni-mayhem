CREATE TABLE [dbo].[ScoreToSpeakerPointsIntervals]
(
	[FromScore] INT NOT NULL, 
    [SpeakerPoints] INT NOT NULL 
)

GO

CREATE UNIQUE INDEX [IX_ScoreToSpeakerPointsIntervals_FromScore] ON [dbo].[ScoreToSpeakerPointsIntervals] ([FromScore])
