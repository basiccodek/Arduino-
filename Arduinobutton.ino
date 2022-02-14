const int buttonPin = 12;

void setup() {
  Serial.begin(9600);
  pinMode(buttonPin, INPUT_PULLUP);
}

void loop() {
  int buttonState = digitalRead(buttonPin);
  if (buttonState == LOW) {
    Serial.println("出力");
    delay(300);
  }
}
