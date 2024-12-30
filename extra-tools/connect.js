const http = require("node:http");

const [ _node, _file, ...args ] = process.argv;

const [host, port, path, method, ...tokens] = args;

const data = tokens.join("");

const opts = {
    hostname: host,
    port: parseInt(port),
    path: path,
    method: method,
    headers: {
        'content-type': 'application/json'
    }
}

const req = http.request(opts, res => {
    res.on("data", data => {
        console.log(`res: ${data}`)
    })
});

req.on('error', err => {
    console.log(`err: ${err}`);
})

if(method === "POST"){
    req.write(data);
}

req.end();
