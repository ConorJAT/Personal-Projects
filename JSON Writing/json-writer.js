// fs (File System) - Native Node.js module that allows access and editing of files
const fs = require("fs");

const user = {
    "id" : 1234,
    "name" : "Conor Race",
    "tier" : "Worker",
    "income": 50000
};

let json = JSON.stringify(user);


// fs.WriteFile
// - Three Params:
//      - String file path  
//      - String of object  
//      - Callback function w/ error parameter.
// - Creates a new json file if file does not exist.
// - Will NOT create a new folder for a new file. Folder has to already exist.
// - Works by completely overriding anything in the json file and replacing it with new info.
fs.writeFile("data.json", json, (error) => {
    if (error){
        console.log(error);
        throw error;
    }

    console.log("JSON Writing Successful!");
});

// Works similarly like writeFile, though error checking has to be done manually.
// fs.writeFileSync("data.json", json);


// fs.ReadFile
// - Two Params:
//      - String file path
//      - Callback function w/ error and data parameters.
fs.readFile("data.json", (error, data) => {
    if (error){
        console.log(error);
        throw error;
    }

    json = JSON.parse(data);
    console.log(json);
});

const data = fs.readFileSync("data.json");
const parseData = JSON.parse(data);
console.log(parseData);

