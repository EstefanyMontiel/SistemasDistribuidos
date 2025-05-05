from flask import Flask, jsonify

app = Flask(__name__)

counter = 0

@app.route("/", methods=["GET"])
def hello_docker():
    global counter
    counter += 1
    return jsonify({"message": "Hola mundo", "counter": counter})

if __name__ == "__main__":
    app.run(host="0.0.0.0", port=5000)
