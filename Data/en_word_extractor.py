import json


with open("./en_words_dictionary.json", "r", encoding="utf-8") as input_file:
	words = json.load(input_file)

five_letter_words = {
	word: value
	for word, value in words.items()
	if isinstance(word, str) and len(word) == 5 and word.isalpha()
}

with open(
	"./words_to_guess.json", "w", encoding="utf-8"
) as output_file:
	json.dump(five_letter_words, output_file, indent=2)

