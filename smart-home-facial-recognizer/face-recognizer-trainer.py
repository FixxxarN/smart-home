import cv2
import os
import numpy as np
from PIL import Image
import pickle

BASE_DIR = os.path.dirname(os.path.abspath(__file__))
image_dir = os.path.join(BASE_DIR, "images")

face_cascade = cv2.CascadeClassifier("haarcascade_frontalface_alt2.xml")

recognizer = cv2.face.createLBPHFaceRecognizer()

current_id = 0
name_ids = {}
y_names = []
x_train = []

for root, dir, files in os.walk(image_dir):
    for file in files:
        if file.endswith("png") or file.endswith("jpg"):
            path = os.path.join(root, file)
            name = os.path.basename(root).replace(" ", "-").lower()
            if not name in name_ids:
                name_ids[name] = current_id
                current_id += 1
            id_ = name_ids[name]
            
            pil_image = Image.open(path).convert("L")
            size = (550, 550)
            final_image = pil_image.resize(size, Image.ANTIALIAS)
            image_array = np.array(final_image, "uint8")
            
            faces = face_cascade.detectMultiScale(image_array, 1.1, 4)
            
            for(x, y, w, h) in faces:
                roi = image_array[y:y+h, x:x+w]
                x_train.append(roi)
                y_names.append(id_)
        
with open("names.pkl", "wb") as f:
    pickle.dump(name_ids, f)
        
recognizer.train(x_train, np.array(y_names))
recognizer.save("face-training-data.yml")