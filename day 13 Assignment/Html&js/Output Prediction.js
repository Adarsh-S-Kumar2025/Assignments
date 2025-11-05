var num = 10;
        function test() {
            var num = 20;
            if (true) {
                let num = 30;
                console.log("Inside if:", num);
            }
            console.log("Inside function:", num);
        }
        test();
        console.log("Outside:", num);
