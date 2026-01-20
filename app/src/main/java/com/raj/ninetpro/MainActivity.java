package com.raj.ninetpro;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;

public class MainActivity extends Activity {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        // इंजन चालू करने और बटन के कनेक्शन यहाँ हैं
        findViewById(R.id.btn_next).setOnClickListener(v -> 
            Toast.makeText(this, "Next Video Loading...", Toast.LENGTH_SHORT).show());

        findViewById(R.id.btn_download).setOnClickListener(v -> 
            Toast.makeText(this, "Downloading to SD Card...", Toast.LENGTH_LONG).show());

        findViewById(R.id.btn_speaker).setOnClickListener(v -> 
            Toast.makeText(this, "Voice Engine Listening...", Toast.LENGTH_SHORT).show());
    }
}
