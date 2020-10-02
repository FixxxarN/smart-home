#import time will be used later when we give the camera some seconds to warm up.
import time

#cv2 is the module that will do all the training and face recognition.
import cv2

from imutils.video import VideoStream
import imutils

#pickle is used to write to files and read them
import pickle

#Cascades are used to know what the recognizer will look for
face_cascade = cv2.CascadeClassifier("haarcascade_frontalface_alt2.xml")

recognizer = cv2.face.createLBPHFaceRecognizer()

recognizer.load("face-training-data.yml")

#Dictionary for names and id's
names = {}

with open("names.pkl", "rb") as f:
    original_names = pickle.load(f)
    names = {v:k for k,v in original_names.items()}
    
#This is true because a Raspberry PI Camera is being used for this project
usingPiCamera = True
frameSize = (320, 240)
framerate = 32

vs = VideoStream(src=0, usePiCamera=usingPiCamera, resolution=frameSize, framerate=framerate).start()

#Let's the camera warm up in 2 seconds
time.sleep(2.0)

while True:
    frame = vs.read()
    
    gray = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)
    
    faces = face_cascade.detectMultiScale(gray, 1.1, 4)
    
    if not usingPiCamera:
        frame = imutils.resize(frame, width=frameSize(0))
        
    for(x, y, w, h) in faces:
        roi_gray = gray[y:y+h, x:x+w]
        cv2.rectangle(frame, (x,y), (x+w, y+h), (0, 0, 0), 2)
        id_, conf = recognizer.predict(roi_gray)
        if conf >= 80:
            font = cv2.FONT_HERSHEY_SIMPLEX
            name = names[id_]
            color = (255, 255, 255)
            stroke = 2
            cv2.putText(frame, name, (x,y), font, 1, color, stroke, cv2.LINE_AA)
            
    cv2.imshow('Face-recognizer', frame)
    key = cv2.waitKey(1) & 0xFF
    
    if key == ord("q"):
        break
    
cv2.destroyAllWindows()
vs.stop()